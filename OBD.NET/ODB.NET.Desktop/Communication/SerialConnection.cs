using System;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OBD.NET.Communication
{
    public class SerialConnection : ISerialConnection
    {
        #region Properties & Fields

        private readonly EnhancedSerialPort _serialPort;
        private readonly int _timeout;

        public bool IsOpen => _serialPort?.IsOpen ?? false;

        private readonly byte[] _readBuffer = new byte[1024];
        private readonly StringBuilder _lineBuffer = new StringBuilder();

        private readonly AutoResetEvent _hasPrompt = new AutoResetEvent(true);

        #endregion

        #region Events

        public event EventHandler<string> MessageReceived;

        #endregion

        #region Constructors

        public SerialConnection(string port, int baudRate = 38400, Parity parity = Parity.None, StopBits stopBits = StopBits.One,
            Handshake handshake = Handshake.None, int timeout = 5000)
        {
            this._timeout = timeout;
            _serialPort = new EnhancedSerialPort(port, baudRate, parity)
            {
                StopBits = stopBits,
                Handshake = handshake,
                ReadTimeout = timeout,
                WriteTimeout = timeout
            };

            _serialPort.DataReceived += SerialPortOnDataReceived;
        }

        #endregion

        #region Methods

        public void Connect()
        {
            _serialPort.Open();
            Thread.Sleep(5000);
            Write("\r");
        }

        public void Write(string text)
        {
            if (!_hasPrompt.WaitOne(_timeout))
                throw new TimeoutException("No prompt received");

            _serialPort.Write(text);
        }

        private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
        {
            int count = _serialPort.Read(_readBuffer, 0, _serialPort.BytesToRead);
            for (int i = 0; i < count; i++)
            {
                char c = (char)_readBuffer[i];
                switch (c)
                {
                    case '\r':
                        FinishLine();
                        break;

                    case '>':
                        _hasPrompt.Set();
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
            string line = _lineBuffer.ToString();
            _lineBuffer.Clear();

            MessageReceived?.Invoke(this, line);
        }

        public void Dispose()
        {
            _serialPort?.Dispose();
        }

        public Task ConnectAsync()
        {
            throw new NotSupportedException("Asynchronous operations not supported");
        }

        public Task WriteAsync(string text)
        {
            throw new NotSupportedException("Asynchronous operations not supported");
        }

        #endregion
    }
}
