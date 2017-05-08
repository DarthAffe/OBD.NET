using System;
using OBD.NET.Communication;
using OBD.NET.Exceptions;
using OBD.NET.Logging;
using System.Threading.Tasks;
using OBD.NET.Common.Communication.EventArgs;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;

namespace OBD.NET.Devices
{ 
    /// <summary>
    /// Base class used for communicating with the device
    /// </summary>
    public abstract class SerialDevice : IDisposable
    {
        private BlockingCollection<string> commandQueue;

        private readonly StringBuilder _lineBuffer = new StringBuilder();

        private readonly AutoResetEvent commandFinishedEvent = new AutoResetEvent(false);

        private Task commandWorkerTask;
        private CancellationTokenSource commandCancellationToken;
        
        /// <summary>
        /// Logger instance
        /// </summary>
        protected IOBDLogger Logger { get; }

        /// <summary>
        /// Low level connection
        /// </summary>
        protected ISerialConnection Connection { get; }

        /// <summary>
        /// Terminator of the protocol message
        /// </summary>
        protected char Terminator { get; set; }
                
        
        #region Constructors

        private SerialDevice()
        {
            commandQueue = new BlockingCollection<string>();
        }

        protected SerialDevice(ISerialConnection connection, char terminator = '\r', IOBDLogger logger = null)
            :this()
        {
            Connection = connection;
            Terminator = terminator;
            Logger = logger;

            connection.DataReceived += OnDataReceived;
        }


        #endregion
        
        #region Methods

        
        /// <summary>
        /// Initializes the device
        /// </summary>
        public virtual async void Initialize()
        {
            if (Connection.IsAsync)
            {
                await Connection.ConnectAsync();
            }
            else
            {
                Connection.Connect();
            }
            CheckConnectionAndStartWorker();
        }

        private void CheckConnectionAndStartWorker()
        {
            if (!Connection.IsOpen)
            {
                Logger?.WriteLine("Failed to open Serial-Connection.", OBDLogLevel.Error);
                throw new SerialException("Failed to open Serial-Connection.");
            }
            else
            { 
                Logger?.WriteLine("Opened Serial-Connection!", OBDLogLevel.Debug);
            }

            commandCancellationToken = new CancellationTokenSource();
            commandWorkerTask = Task.Factory.StartNew(CommandWorker);
        }

        private async void CommandWorker()
        {
            while (!commandCancellationToken.IsCancellationRequested)
            {
                string command = null;
                commandQueue.TryTake(out command, Timeout.Infinite, commandCancellationToken.Token);
                Logger?.WriteLine("Writing Command: '" + command.Replace('\r', '\'') + "'", OBDLogLevel.Verbose);

                if (Connection.IsAsync)
                {
                    await Connection.WriteAsync(Encoding.ASCII.GetBytes(command));
                }
                else
                {
                    Connection.Write(Encoding.ASCII.GetBytes(command));

                }
                //wait for command to finish
                commandFinishedEvent.WaitOne();
                
            }
        }

        protected virtual void SendCommand(string command)
        {
            if (!Connection.IsOpen)
            {
                throw new InvalidOperationException("Not connected");
            }

            command = PrepareCommand(command);
            Logger?.WriteLine("Queuing Command: '" + command.Replace('\r', '\'') + "'", OBDLogLevel.Verbose);
            commandQueue.Add(command);         
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
                        commandFinishedEvent.Set();
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

        private void FinishLine()
        {
            string line = _lineBuffer.ToString().Trim();
            _lineBuffer.Clear();

            if (string.IsNullOrWhiteSpace(line)) return;
            Logger?.WriteLine("Response: '" + line + "'", OBDLogLevel.Verbose);

            ProcessMessage(line);
        }

        
        protected abstract void ProcessMessage(string message);
        
        public virtual void Dispose()
        {
            Connection?.Dispose();
        }

        #endregion
    }
}
