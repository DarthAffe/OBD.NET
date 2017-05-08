using System;
using OBD.NET.Communication;
using OBD.NET.Exceptions;
using OBD.NET.Logging;
using System.Threading.Tasks;
using OBD.NET.Common.Communication.EventArgs;

namespace OBD.NET.Devices
{ 
    /// <summary>
    /// Base class used for communicating with the device
    /// </summary>
    public abstract class SerialDevice : IDisposable
    {
        private System.Collections.Generic.Queue<string> commandQueue;

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
            commandQueue = new System.Collections.Generic.Queue<string>();
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

        private void OnDataReceived(object sender, DataReceivedEventArgs e)
        {

        }

        #region Methods

        
        /// <summary>
        /// Initializes the device
        /// </summary>
        public virtual void Initialize()
        {

            Connection.Connect();
            CheckConnection();
        }

        /// <summary>
        /// Initializes the device async
        /// </summary>
        /// <returns></returns>
        public virtual async Task InitializeAsync()
        {
            await Connection.ConnectAsync();
            CheckConnection();
        }

        private void CheckConnection()
        {
            if (!Connection.IsOpen)
            {
                Logger?.WriteLine("Failed to open Serial-Connection.", OBDLogLevel.Error);
                throw new SerialException("Failed to open Serial-Connection.");
            }
            else
                Logger?.WriteLine("Opened Serial-Connection!", OBDLogLevel.Debug);
        }

        

        protected virtual void SendCommand(string command)
        {
            if (!Connection.IsOpen)
            {
                throw new InvalidOperationException("Not connected");
            } 

            command = PrepareCommand(command);
            Logger?.WriteLine("Queuing Command: '" + command.Replace('\r', '\'') + "'", OBDLogLevel.Verbose);
            commandQueue.Enqueue(command);
//            Logger?.WriteLine("Writing Command: '" + command.Replace('\r', '\'') + "'", OBDLogLevel.Verbose);
 //           Connection.Write(command);
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

        private void SerialMessageReceived(object sender, string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return;

            Logger?.WriteLine("Response: '" + message + "'", OBDLogLevel.Verbose);
            ProcessMessage(message.Trim());
        }

        protected abstract void ProcessMessage(string message);
        
        public virtual void Dispose()
        {
            Connection?.Dispose();
        }

        #endregion
    }
}
