using System;
using System.Runtime.InteropServices.WindowsRuntime;
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
        private DataWriter _writer;

        private readonly byte[] _readBuffer = new byte[1024];
        private readonly StringBuilder _lineBuffer = new StringBuilder();

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private Task _readerTask;
        
        /// <summary>
        /// Gets a value indicating whether this connection is open.
        /// </summary>
        /// <value>
        /// <c>true</c> if this connection is open; otherwise, <c>false</c>.
        /// </value>
        public bool IsOpen { get; private set; }

        /// <summary>
        /// Occurs when a full line was received
        /// </summary>
        public event EventHandler<string> MessageReceived;

        /// <summary>
        /// Connects the serial port.
        /// </summary>
        /// <exception cref="System.NotSupportedException">Synchronous operations not supported</exception>
        public void Connect()
        {
            throw new NotSupportedException("Synchronous operations not supported");
        }

        /// <summary>
        /// Connects the serial port asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task ConnectAsync()
        {
            var services = await Windows.Devices.Enumeration.DeviceInformation
                .FindAllAsync(RfcommDeviceService.GetDeviceSelector(RfcommServiceId.SerialPort));

            //use first serial service
            if (services.Count > 0)
            {
                // Initialize the target Bluetooth BR device
                var service = await RfcommDeviceService.FromIdAsync(services[0].Id);

                // Check that the service meets this App's minimum requirement

                _socket = new StreamSocket();
                await _socket.ConnectAsync(service.ConnectionHostName,
                    service.ConnectionServiceName);
                _writer = new DataWriter(_socket.OutputStream);
                _readerTask = StartReader();
                IsOpen = true;
            }
        }

        /// <summary>
        /// Writes the specified text to the serial connection
        /// </summary>
        /// <param name="text">The text.</param>
        /// <exception cref="System.NotImplementedException">Synchronous operations not supported</exception>
        public void Write(string text)
        {
            throw new NotImplementedException("Synchronous operations not supported");
        }

        /// <summary>
        /// Writes the specified text to the serial connection asynchronously
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public async Task WriteAsync(string text)
        {
            _writer.WriteString(text);
            await _writer.StoreAsync();
            await _writer.FlushAsync();
        }

        private Task StartReader()
        {
             return Task.Factory.StartNew(async () =>
             {

                 var buffer = _readBuffer.AsBuffer();
                 while (!_cancellationTokenSource.IsCancellationRequested)
                 {
                     var readData = await _socket.InputStream.ReadAsync(buffer, buffer.Capacity, InputStreamOptions.Partial);
                     SerialPortOnDataReceived(readData);
                 }
             }, _cancellationTokenSource.Token);
        }

        private void SerialPortOnDataReceived(IBuffer buffer)
        {
            
            for (uint i = 0; i < buffer.Length; i++)
            {
                char c = (char)buffer.GetByte(i);
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
            _cancellationTokenSource?.Cancel();
            _readerTask?.Wait();
            _socket?.Dispose();
        }

        
    }
}
