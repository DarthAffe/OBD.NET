#if NET5_0_OR_GREATER

using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading.Tasks;
using OBD.NET.Communication.EventArgs;

namespace OBD.NET.Communication;

public class SerialConnection : ISerialConnection
{
    #region Properties & Fields

    private readonly SerialPort _serialPort;

    public bool IsOpen => _serialPort.IsOpen;
    public bool IsAsync => false;

    private readonly byte[] _readBuffer = new byte[1024];

    #endregion

    #region Events

    public event EventHandler<DataReceivedEventArgs>? DataReceived = delegate { };

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

    public static IEnumerable<string> GetAvailablePorts() => SerialPort.GetPortNames();

    public void Connect() => _serialPort.Open();

    private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
    {
        int count = _serialPort.Read(_readBuffer, 0, _serialPort.BytesToRead);
        DataReceived?.Invoke(this, new DataReceivedEventArgs(count, _readBuffer));
    }

    public void Dispose() => _serialPort.Dispose();

    public Task ConnectAsync()
    {
        try
        {
            Connect();
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            return Task.FromException(ex);
        }
    }

    public Task WriteAsync(byte[] data)
    {
        try
        {
            Write(data);
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            return Task.FromException(ex);
        }
    }

    public void Write(byte[] data) => _serialPort.Write(data, 0, data.Length);

    #endregion
}

#else

using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading.Tasks;
using OBD.NET.Communication.EventArgs;

namespace OBD.NET.Communication;

public class SerialConnection : ISerialConnection
{
    #region Properties & Fields

    private readonly EnhancedSerialPort _serialPort;

    public bool IsOpen => _serialPort?.IsOpen ?? false;
    public bool IsAsync => false;

    private readonly byte[] _readBuffer = new byte[1024];

    #endregion

    #region Events

    public event EventHandler<DataReceivedEventArgs>? DataReceived;

    #endregion

    #region Constructors

    public SerialConnection(string port, int baudRate = 38400, Parity parity = Parity.None, StopBits stopBits = StopBits.One,
        Handshake handshake = Handshake.None, int timeout = 5000)
    {
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

    public static IEnumerable<string> GetAvailablePorts() => SerialPort.GetPortNames();

    public void Connect() => _serialPort.Open();

    private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
    {
        int count = _serialPort.Read(_readBuffer, 0, _serialPort.BytesToRead);
        DataReceived?.Invoke(this, new DataReceivedEventArgs(count, _readBuffer));
    }

    public void Dispose() => _serialPort.Dispose();
    
    public Task ConnectAsync()
    {
        try
        {
            Connect();
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            return Task.FromException(ex);
        }
    }

    public Task WriteAsync(byte[] data)
    {
        try
        {
            Write(data);
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            return Task.FromException(ex);
        }
    }

    public void Write(byte[] data) => _serialPort.Write(data, 0, data.Length);

    #endregion
}

#endif
