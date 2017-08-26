using System;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OBD.NET.Common.Communication;
using OBD.NET.Common.Communication.EventArgs;
using OBD.NET.Common.Exceptions;
using OBD.NET.Common.Logging;

namespace OBD.NET.Common.Devices
{
    /// <summary>
    /// Base class used for communicating with the device
    /// </summary>
    public abstract class SerialDevice : IDisposable
    {
        #region Properties & Fields

        private readonly BlockingCollection<QueuedCommand> _commandQueue = new BlockingCollection<QueuedCommand>();
        private readonly StringBuilder _lineBuffer = new StringBuilder();
        private readonly AutoResetEvent _commandFinishedEvent = new AutoResetEvent(false);
        private Task _commandWorkerTask;
        private CancellationTokenSource _commandCancellationToken;

        private volatile int _queueSize = 0;
        private readonly ManualResetEvent _queueEmptyEvent = new ManualResetEvent(true);

        public int QueueSize => _queueSize;

        protected QueuedCommand CurrentCommand;
        protected IOBDLogger Logger { get; }
        protected ISerialConnection Connection { get; }
        protected char Terminator { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SerialDevice"/> class.
        /// </summary>
        /// <param name="connection">connection.</param>
        /// <param name="terminator">terminator used for terminating the command message</param>
        /// <param name="logger">logger instance</param>
        protected SerialDevice(ISerialConnection connection, char terminator = '\r', IOBDLogger logger = null)
        {
            this.Connection = connection;
            this.Terminator = terminator;
            this.Logger = logger;

            connection.DataReceived += OnDataReceived;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the device
        /// </summary>
        public virtual void Initialize()
        {
            Connection.Connect();
            CheckConnectionAndStartWorker();
        }

        /// <summary>
        /// Initializes the device
        /// </summary>
        public virtual async Task InitializeAsync()
        {
            await Connection.ConnectAsync();
            CheckConnectionAndStartWorker();
        }

        /// <summary>
        /// Checks the connection and starts background worker which is sending the commands
        /// </summary>
        /// <exception cref="SerialException">Failed to open Serial-Connection.</exception>
        private void CheckConnectionAndStartWorker()
        {
            if (!Connection.IsOpen)
            {
                Logger?.WriteLine("Failed to open Serial-Connection.", OBDLogLevel.Error);
                throw new SerialException("Failed to open Serial-Connection.");
            }

            Logger?.WriteLine("Opened Serial-Connection!", OBDLogLevel.Debug);

            _commandCancellationToken = new CancellationTokenSource();
            _commandWorkerTask = Task.Factory.StartNew(CommandWorker);
        }


        /// <summary>
        /// Sends the command.
        /// </summary>
        /// <param name="command">command string</param>
        /// <exception cref="System.InvalidOperationException">Not connected</exception>
        protected virtual CommandResult SendCommand(string command)
        {
            if (!Connection.IsOpen)
                throw new InvalidOperationException("Not connected");

            command = PrepareCommand(command);
            Logger?.WriteLine("Queuing Command: '" + command.Replace('\r', '\'') + "'", OBDLogLevel.Verbose);

            QueuedCommand cmd = new QueuedCommand(command);
            _queueEmptyEvent.Reset();
            _queueSize++;
            _commandQueue.Add(cmd);

            return cmd.CommandResult;
        }

        /// <summary>
        /// Prepares the command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        protected virtual string PrepareCommand(string command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            if (!command.EndsWith(Terminator.ToString(), StringComparison.Ordinal))
                command += Terminator;

            return command;
        }

        /// <summary>
        /// Called when data is received from the serial device
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataReceivedEventArgs"/> instance containing the event data.</param>
        private void OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            for (int i = 0; i < e.Count; i++)
            {
                char c = (char)e.Data[i];
                switch (c)
                {
                    case '\r':
                        FinishLine();
                        break;

                    case '>':
                        CurrentCommand.CommandResult.WaitHandle.Set();
                        _commandFinishedEvent.Set();
                        break;

                    case '\n':
                    case (char)0x00:
                        break; // ignore

                    default:
                        _lineBuffer.Append(c);
                        break;
                }
            }
        }

        /// <summary>
        /// Signals a final message
        /// </summary>
        private void FinishLine()
        {
            string line = _lineBuffer.ToString().Trim();
            _lineBuffer.Clear();

            if (string.IsNullOrWhiteSpace(line)) return;
            Logger?.WriteLine("Response: '" + line + "'", OBDLogLevel.Verbose);

            InternalProcessMessage(line);
        }

        /// <summary>
        /// Process message and sets the result 
        /// </summary>
        /// <param name="message">The message.</param>
        private void InternalProcessMessage(string message)
        {
            object data = ProcessMessage(message);
            CurrentCommand.CommandResult.Result = data;
        }

        /// <summary>
        /// Processes the message.
        /// </summary>
        /// <param name="message">message received</param>
        /// <returns>result data</returns>
        protected abstract object ProcessMessage(string message);

        /// <summary>
        /// Worker method for sending commands
        /// </summary>
        private async void CommandWorker()
        {
            while (!_commandCancellationToken.IsCancellationRequested)
            {
                CurrentCommand = null;

                if (_queueSize == 0)
                    _queueEmptyEvent.Set();

                try
                {
                    if (_commandQueue.TryTake(out CurrentCommand, 10, _commandCancellationToken.Token))
                    {
                        _queueSize--;

                        Logger?.WriteLine("Writing Command: '" + CurrentCommand.CommandText.Replace('\r', '\'') + "'", OBDLogLevel.Verbose);

                        if (Connection.IsAsync)
                            await Connection.WriteAsync(Encoding.ASCII.GetBytes(CurrentCommand.CommandText));
                        else
                            Connection.Write(Encoding.ASCII.GetBytes(CurrentCommand.CommandText));

                        //wait for command to finish
                        _commandFinishedEvent.WaitOne();
                    }
                }
                catch (OperationCanceledException) { /*ignore, because it is thrown when the cancellation token is canceled*/}
            }
        }

        public void WaitQueue() => _queueEmptyEvent.WaitOne();

        public async Task WaitQueueAsync() => await Task.Run(() => WaitQueue());

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            _commandQueue.CompleteAdding();
            _commandCancellationToken?.Cancel();
            _commandWorkerTask?.Wait();
            Connection?.Dispose();
        }

        #endregion
    }
}
