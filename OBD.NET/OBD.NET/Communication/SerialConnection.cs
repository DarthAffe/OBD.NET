using System.IO.Ports;
using System.Text;
using OBD.NET.Communication.EventArgs;

namespace OBD.NET.Communication;

public class SerialConnection : ISerialConnection
{
    #region Properties & Fields

    private readonly SerialPort _serialPort;

    public bool IsOpen => _serialPort?.IsOpen ?? false;
    public bool IsAsync => false;

    private readonly byte[] _readBuffer = new byte[1024];
    private readonly StringBuilder _lineBuffer = new StringBuilder();

    private readonly AutoResetEvent _hasPrompt = new AutoResetEvent(true);

    #endregion

    #region Events

    public event EventHandler<DataReceivedEventArgs> DataReceived = delegate {  };

    #endregion

    #region Constructors

    public SerialConnection(string port, int baudRate = 38400, Parity parity = Parity.None, StopBits stopBits = StopBits.One,
        Handshake handshake = Handshake.None, int timeout = 5000)
    {
        _serialPort = new SerialPort(port, baudRate, parity)
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

    public static IEnumerable<string> GetAvailablePorts()
    {
        return SerialPort.GetPortNames();
    }

    public void Connect() => _serialPort.Open();

    private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
    {
        int count = _serialPort.Read(_readBuffer, 0, _serialPort.BytesToRead);
        DataReceived?.Invoke(this, new DataReceivedEventArgs(count, _readBuffer));
    }

    public void Dispose() => _serialPort?.Dispose();

    public Task ConnectAsync() => throw new NotSupportedException("Asynchronous operations not supported");

    public Task WriteAsync(byte[] data) => throw new NotSupportedException("Asynchronous operations not supported");

    public void Write(byte[] data) => _serialPort.Write(data, 0, data.Length);

    #endregion
}