using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Rfcomm;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace OBD.NET.Communication
{
    public class BluetoothSerialConnection : ISerialConnection
    {

        private StreamSocket _socket;
        private DataReader _reader;
        private DataWriter _writer;

        private readonly byte[] _readBuffer = new byte[1024];
        private readonly StringBuilder _lineBuffer = new StringBuilder();
        
        /// <summary>
        /// Gets a value indicating whether this connection is open.
        /// </summary>
        /// <value>
        /// <c>true</c> if this connection is open; otherwise, <c>false</c>.
        /// </value>
        public bool IsOpen { get; private set; }


        public event EventHandler<string> MessageReceived;

        public void Connect()
        {
            throw new NotSupportedException();
        }

        public async Task ConnectAsync()
        {
            var services = await Windows.Devices.Enumeration.DeviceInformation
                .FindAllAsync(RfcommDeviceService.GetDeviceSelector(RfcommServiceId.SerialPort));

            if (services.Count > 0)
            {
                // Initialize the target Bluetooth BR device
                var service = await RfcommDeviceService.FromIdAsync(services[0].Id);

                // Check that the service meets this App's minimum requirement

                _socket = new StreamSocket();
                await _socket.ConnectAsync(service.ConnectionHostName,
                    service.ConnectionServiceName);
                _writer = new DataWriter(_socket.OutputStream);
                StartReader();
                

            }
        }

        private void StartReader()
        {
            Task.Factory.StartNew(async () =>
            {
                _reader = new DataReader(_socket.InputStream);
                while (true)
                {
                    await _reader.LoadAsync(1);
                    var data = _reader.ReadByte();
                    _readBuffer[0] = data;
                    SerialPortOnDataReceived();
                }

            });
        }

        private void SerialPortOnDataReceived()
        {
            int count = 1;
            for (int i = 0; i < count; i++)
            {
                char c = (char)_readBuffer[i];
                switch (c)
                {
                    case '\r':
                        FinishLine();
                        break;

                    case '>':
                        continue; //ignore

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
            _socket?.Dispose();
        }

        public void Write(string text)
        {
            throw new NotImplementedException();
        }

        public async Task WriteAsync(string text)
        {
            _writer.WriteString(text);
            await _writer.StoreAsync();
            await _writer.FlushAsync();
        }
    }
}
