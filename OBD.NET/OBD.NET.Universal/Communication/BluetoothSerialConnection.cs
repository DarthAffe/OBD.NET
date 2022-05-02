using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using OBD.NET.Communication.EventArgs;
using Windows.Devices.Bluetooth.Rfcomm;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using System.Linq;
using Windows.Devices.Enumeration;

// ReSharper disable once CheckNamespace
namespace OBD.NET.Communication
{
    /// <summary>
    /// Bluetooth OBD serial implementation
    /// </summary>
    /// <seealso cref="OBD.NET.Communication.ISerialConnection" />
    public class BluetoothSerialConnection : ISerialConnection
    {
        #region Properties & Fields

        private StreamSocket _socket;
        private DataWriter _writer;

        private readonly byte[] _readBuffer = new byte[1024];

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private Task _readerTask;

        private string _device;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BluetoothSerialConnection"/> class.
        /// </summary>
        public BluetoothSerialConnection()
        {
            _device = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BluetoothSerialConnection"/> class.
        /// </summary>
        /// <param name="deviceName">Name of the _device.</param>
        /// <param name="logger">The logger.</param>
        public BluetoothSerialConnection(string deviceName)
        {
            this._device = deviceName;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a value indicating whether this instance is open.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is open; otherwise, <c>false</c>.
        /// </value>
        public bool IsOpen { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance uses asynchronous IO
        /// </summary>
        /// <remarks>
        /// Has to be set to true if asynchronous IO is supported.
        /// If true async methods have to be implemented
        /// </remarks>
        public bool IsAsync => true;

        /// <summary>
        /// Occurs when a full line was received
        /// </summary>
        public event EventHandler<DataReceivedEventArgs> DataReceived;

        /// <summary>
        /// Connects the serial port.
        /// </summary>
        /// <exception cref="System.NotSupportedException">Synchronous operations not supported</exception>
        public void Connect() => throw new NotSupportedException("Synchronous operations not supported on UWP platform");

        /// <summary>
        /// Connects the serial port asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task ConnectAsync()
        {
            DeviceInformationCollection services = await DeviceInformation.FindAllAsync(RfcommDeviceService.GetDeviceSelector(RfcommServiceId.SerialPort));

            //use first serial service
            if (services.Count > 0)
            {
                string id = services[0].Id;

                //use predefined _device from constructor
                if (!string.IsNullOrWhiteSpace(_device))
                {
                    id = services.Where(x => x.Name.Equals(_device, StringComparison.OrdinalIgnoreCase))
                                 .Select(x => x.Id)
                                 .FirstOrDefault();

                    if (id == null)
                        throw new InvalidOperationException($"Device {_device} not found");
                }

                // Initialize the target Bluetooth _device
                RfcommDeviceService service = await RfcommDeviceService.FromIdAsync(id);

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
        /// <exception cref="System.NotImplementedException">Synchronous operations not supported</exception>
        public void Write(byte[] data) => throw new NotSupportedException("Synchronous operations not supported on UWP platform");

        /// <summary>
        /// Writes the specified text to the serial connection asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task WriteAsync(byte[] data)
        {
            _writer.WriteBytes(data);
            await _writer.StoreAsync();
            await _writer.FlushAsync();
        }

        private Task StartReader()
        {
            return Task.Factory.StartNew(async () =>
            {

                IBuffer buffer = _readBuffer.AsBuffer();
                while (!_cancellationTokenSource.IsCancellationRequested)
                {
                    IBuffer readData = await _socket.InputStream.ReadAsync(buffer, buffer.Capacity, InputStreamOptions.Partial);
                    SerialPortOnDataReceived(readData);
                }
            }, _cancellationTokenSource.Token);
        }

        private void SerialPortOnDataReceived(IBuffer buffer) => DataReceived?.Invoke(this, new DataReceivedEventArgs((int)buffer.Length, _readBuffer));

        public void Dispose()
        {
            _cancellationTokenSource?.Cancel();
            _readerTask?.Wait();
            _socket?.Dispose();
        }
    }

    #endregion
}
