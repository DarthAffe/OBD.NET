#if !NET5_0_OR_GREATER

// Copyright 2013 Antanas Veiverys www.veiverys.com
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.ComponentModel;
using System.IO;
using System.IO.Ports;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

// Source: http://antanas.veiverys.com/mono-serialport-datareceived-event-workaround-using-a-derived-class/
namespace OBD.NET.Communication;

[DesignerCategory("Code")]
public class EnhancedSerialPort : SerialPort
{
    #region Properties & Fields

    // private member access via reflection
    private int _fd;
    private FieldInfo? _disposedFieldInfo;
    private object? _dataReceived;
    private Thread? _thread;

    #endregion

    #region DLLImports

    [DllImport("MonoPosixHelper", SetLastError = true)]
    private static extern bool poll_serial(int fd, out int error, int timeout);

    [DllImport("libc")]
    private static extern IntPtr strerror(int errnum);

    #endregion

    #region Constructors

    public EnhancedSerialPort()
        : base()
    { }

    public EnhancedSerialPort(IContainer container)
        : base(container)
    { }

    public EnhancedSerialPort(string portName)
        : base(portName)
    { }

    public EnhancedSerialPort(string portName, int baudRate)
        : base(portName, baudRate)
    { }

    public EnhancedSerialPort(string portName, int baudRate, Parity parity)
        : base(portName, baudRate, parity)
    { }

    public EnhancedSerialPort(string portName, int baudRate, Parity parity, int dataBits)
        : base(portName, baudRate, parity, dataBits)
    { }

    public EnhancedSerialPort(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        : base(portName, baudRate, parity, dataBits, stopBits)
    { }

    #endregion

    #region Methods

    public new void Open()
    {
        base.Open();

        if (!IsWindows)
        {
            FieldInfo? fieldInfo = BaseStream.GetType().GetField("fd", BindingFlags.Instance | BindingFlags.NonPublic);
            if (fieldInfo == null) throw new NotSupportedException("Unable to initialize SerialPort - 'fd'-field is missing.");
            _fd = (int)fieldInfo.GetValue(BaseStream)!;

            _disposedFieldInfo = BaseStream.GetType().GetField("disposed", BindingFlags.Instance | BindingFlags.NonPublic) ?? throw new NotSupportedException("Unable to initialize SerialPort - 'disposed'-field is missing.");

            fieldInfo = typeof(SerialPort).GetField("data_received", BindingFlags.Instance | BindingFlags.NonPublic);
            if (fieldInfo == null) throw new NotSupportedException("Unable to initialize SerialPort - 'data_received'-field is missing.");
            _dataReceived = fieldInfo.GetValue(this);

            _thread = new Thread(EventThreadFunction);
            _thread.Start();
        }
    }

    private static bool IsWindows
    {
        get
        {
            PlatformID id = Environment.OSVersion.Platform;
            return (id == PlatformID.Win32Windows) || (id == PlatformID.Win32NT); // WinCE not supported
        }
    }

    private void EventThreadFunction()
    {
        do
        {
            try
            {
                Stream? stream = BaseStream;
                if (stream == null)
                    return;

                if (Poll(stream, ReadTimeout))
                    OnDataReceived(null!);
            }
            catch
            {
                return;
            }
        } while (IsOpen);
    }

    private void OnDataReceived(SerialDataReceivedEventArgs args)
    {
        SerialDataReceivedEventHandler? handler = Events[_dataReceived!] as SerialDataReceivedEventHandler;
        handler?.Invoke(this, args);
    }

    private bool Poll(Stream stream, int timeout)
    {
        CheckDisposed(stream);
        if (IsOpen == false)
            throw new Exception("port is closed");

        bool pollResult = poll_serial(_fd, out int error, ReadTimeout);
        if (error == -1)
            ThrowIOException();

        return pollResult;
    }

    private static void ThrowIOException()
    {
        int errnum = Marshal.GetLastWin32Error();
        string errorMessage = Marshal.PtrToStringAnsi(strerror(errnum))!;

        throw new IOException(errorMessage);
    }

    private void CheckDisposed(Stream stream)
    {
        bool disposed = (bool)_disposedFieldInfo!.GetValue(stream)!;
        if (disposed)
            throw new ObjectDisposedException(stream.GetType().FullName);
    }

    #endregion
}

#endif