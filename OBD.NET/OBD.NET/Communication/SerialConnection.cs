using System;
using System.IO.Ports;

namespace OBD.NET.Communication
{
    public class SerialConnection : IDisposable
    {
        #region Properties & Fields

        private readonly SerialPort _serialPort;

        public bool IsOpen => _serialPort.IsOpen;

        #endregion

        #region Constructors

        public SerialConnection(string port, int baudRate = 38400, Parity parity = Parity.None,
            StopBits stopBits = StopBits.One, Handshake handshake = Handshake.None, int timeout = 5000)
        {
            _serialPort = new SerialPort(port, baudRate, parity)
            {
                StopBits = stopBits,
                Handshake = handshake,
                ReadTimeout = timeout,
                WriteTimeout = timeout
            };
        }

        #endregion

        #region Methods

        public void Connect()
        {
            _serialPort.Open();
        }

        public void Write(string text)
        {
            _serialPort.Write(text);
        }

        public byte ReadByte()
        {
            return (byte)_serialPort.ReadByte();
        }

        public void Dispose()
        {
            _serialPort?.Dispose();
        }

        #endregion
    }
}
