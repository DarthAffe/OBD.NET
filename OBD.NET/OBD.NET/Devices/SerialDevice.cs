using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OBD.NET.Communication;
using OBD.NET.Exceptions;
using OBD.NET.Logging;

namespace OBD.NET.Devices
{
    public abstract class SerialDevice : IDisposable
    {
        #region Properties & Fields

        private readonly byte[] _responseBuffer = new byte[512];

        protected IOBDLogger Logger { get; }

        protected SerialConnection Connection { get; }
        protected char Prompt { get; set; }
        protected char Terminator { get; set; }

        protected abstract string ExpectedNoData { get; }

        #endregion

        #region Constructors

        protected SerialDevice(SerialConnection connection, char prompt = '>', char terminator = '\r', IOBDLogger logger = null)
        {
            this.Connection = connection;
            this.Prompt = prompt;
            this.Terminator = terminator;
            this.Logger = logger;
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

            Thread.Sleep(500);
        }

        protected virtual string SendCommand(string command, string expectedResult = null)
        {
            if (!Connection.IsOpen) return null;

            command = PrepareCommand(command);

            Logger?.WriteLine("Writing Command: '" + command.Replace('\r', '\'') + "'", OBDLogLevel.Verbose);
            Connection.Write(command);

            Logger?.WriteLine("Waiting for response ...", OBDLogLevel.Debug);
            List<string> results = ReadResponse();
            if (expectedResult == null)
                return results.LastOrDefault();

            // DarthAffe 22.02.2017: We expect the lats result to be the "best".
            for (int i = results.Count - 1; i >= 0; i--)
                if (Regex.Match(results[i], expectedResult, RegexOptions.IgnoreCase).Success)
                    return results[i];

            if (results.Any(x => Regex.Match(x, ExpectedNoData, RegexOptions.IgnoreCase).Success))
                return null;

            Logger?.WriteLine("Unexpected Result: '" + string.Join("<\\r>", results) + "' expected was '" + expectedResult + "'", OBDLogLevel.Error);
            throw new UnexpectedResultException(string.Join("<\\r>", results), expectedResult);
        }

        protected virtual string PrepareCommand(string command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            if (!command.EndsWith(Terminator.ToString(), StringComparison.Ordinal))
                command += Terminator;

            return command;
        }

        protected virtual List<string> ReadResponse()
        {
            byte b;
            int count = 0;
            do
            {
                b = Connection.ReadByte();
                if (b != 0x00)
                    _responseBuffer[count++] = b;
            } while (b != Prompt);

            string response = Encoding.ASCII.GetString(_responseBuffer, 0, count - 1); // -1 to remove the prompt
            Logger?.WriteLine("Response: '" + response.Replace("\r", "<\\r>").Replace("\n", "<\\n>") + "'", OBDLogLevel.Verbose);
            return response.Split('\r').Select(x => x.Replace("\r", string.Empty).Replace("\n", string.Empty).Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        }

        public virtual void Dispose()
        {
            Connection?.Dispose();
        }

        #endregion
    }
}
