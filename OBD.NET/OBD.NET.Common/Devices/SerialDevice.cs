using System;
using OBD.NET.Communication;
using OBD.NET.Exceptions;
using OBD.NET.Logging;
using System.Threading.Tasks;

namespace OBD.NET.Devices
{
    public abstract class SerialDevice : IDisposable
    {
        #region Properties & Fields

        protected IOBDLogger Logger { get; }

        protected ISerialConnection Connection { get; }
        protected char Terminator { get; set; }

        #endregion

        #region Constructors

        protected SerialDevice(ISerialConnection connection, char terminator = '\r', IOBDLogger logger = null)
        {
            Connection = connection;
            Terminator = terminator;
            Logger = logger;

            connection.MessageReceived += SerialMessageReceived;
        }

        #endregion

        #region Methods

        public virtual void Initialize()
        {
            Logger?.WriteLine("Opening Serial-Connection ...", OBDLogLevel.Debug);
            Connection.Connect();

            if (!Connection.IsOpen)
            {
                Logger?.WriteLine("Failed to open Serial-Connection.", OBDLogLevel.Error);
                throw new SerialException("Failed to open Serial-Connection.");
            }
            else
                Logger?.WriteLine("Opened Serial-Connection!", OBDLogLevel.Debug);
        }

        public virtual async Task InitializeAsync()
        {
            Logger?.WriteLine("Opening Serial-Connection ...", OBDLogLevel.Debug);
            await Connection.ConnectAsync();

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
            if (!Connection.IsOpen) return;

            command = PrepareCommand(command);

            Logger?.WriteLine("Writing Command: '" + command.Replace('\r', '\'') + "'", OBDLogLevel.Verbose);
            Connection.Write(command);
        }

        protected virtual async Task SendCommandAsync(string command)
        {
            if (!Connection.IsOpen) return;

            command = PrepareCommand(command);

            Logger?.WriteLine("Writing Command: '" + command.Replace('\r', '\'') + "'", OBDLogLevel.Verbose);
            await Connection.WriteAsync(command);
        }

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
