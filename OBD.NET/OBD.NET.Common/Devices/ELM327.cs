using System;
using System.Collections.Generic;
using System.Threading;
using OBD.NET.Commands;
using OBD.NET.Communication;
using OBD.NET.Enums;
using OBD.NET.Events;
using OBD.NET.Events.EventArgs;
using OBD.NET.Extensions;
using OBD.NET.Logging;
using OBD.NET.OBDData;

namespace OBD.NET.Devices
{
    public class ELM327 : SerialDevice
    {
        #region Properties & Fields

        protected Dictionary<Type, IDataEventManager> _dataReceivedEventHandlers = new Dictionary<Type, IDataEventManager>();

        protected static Dictionary<Type, byte> PidCache { get; } = new Dictionary<Type, byte>();
        protected static Dictionary<byte, Type> DataTypeCache { get; } = new Dictionary<byte, Type>();

        protected Mode Mode { get; set; } = Mode.ShowCurrentData; //TODO DarthAffe 26.06.2016: Implement different modes

        #endregion

        #region Events 

        public delegate void DataReceivedEventHandler<T>(object sender, DataReceivedEventArgs<T> args) where T : IOBDData;

        public delegate void RawDataReceivedEventHandler(object sender, RawDataReceivedEventArgs args);
        public event RawDataReceivedEventHandler RawDataReceived;

        #endregion

        #region Constructors

        public ELM327(ISerialConnection connection, IOBDLogger logger = null)
            : base(connection, logger: logger)
        { }

        #endregion

        #region Methods

        public override void Initialize()
        {
            base.Initialize();

            Logger?.WriteLine("Initializing ...", OBDLogLevel.Debug);

            try
            {
                Logger?.WriteLine("Resetting Device ...", OBDLogLevel.Debug);
                SendCommand(ATCommand.ResetDevice);
                Thread.Sleep(1000);

                Logger?.WriteLine("Turning Echo Off ...", OBDLogLevel.Debug);
                SendCommand(ATCommand.EchoOff);

                Logger?.WriteLine("Turning Linefeeds Off ...", OBDLogLevel.Debug);
                SendCommand(ATCommand.LinefeedsOff);

                Logger?.WriteLine("Turning Headers Off ...", OBDLogLevel.Debug);
                SendCommand(ATCommand.HeadersOff);

                Logger?.WriteLine("Turning Spaced Off ...", OBDLogLevel.Debug);
                SendCommand(ATCommand.PrintSpacesOff);

                Logger?.WriteLine("Setting the Protocol to 'Auto' ...", OBDLogLevel.Debug);
                SendCommand(ATCommand.SetProtocolAuto);

                Thread.Sleep(1000);
            }
            // DarthAffe 21.02.2017: This seems to happen sometimes, i don't know why - just retry.
            catch
            {
                Logger?.WriteLine("Failed to initialize the device!", OBDLogLevel.Error);
                throw;
            }
        }

        public virtual void SendCommand(ATCommand command)
        {
            SendCommand(command.Command);
        }

        public virtual void RequestData<T>()
            where T : class, IOBDData, new()
        {
            Logger?.WriteLine("Requesting Type " + typeof(T).Name + " ...", OBDLogLevel.Debug);

            byte pid = ResolvePid<T>();
            RequestData(pid);
        }

        protected virtual void RequestData(byte pid)
        {
            Logger?.WriteLine("Requesting PID " + pid.ToString("X2") + " ...", OBDLogLevel.Debug);
            SendCommand(((byte)Mode).ToString("X2") + pid.ToString("X2"));
        }

        protected override void ProcessMessage(string message)
        {
            DateTime timestamp = DateTime.Now;

            RawDataReceived?.Invoke(this, new RawDataReceivedEventArgs(message, timestamp));

            if (message.Length > 4)
                if (message[0] == '4')
                {
                    byte mode = (byte)message[1].GetHexVal();
                    if (mode == (byte)Mode)
                    {
                        byte pid = (byte)message.Substring(2, 2).GetHexVal();
                        Type dataType;
                        if (DataTypeCache.TryGetValue(pid, out dataType))
                        {
                            IOBDData obdData = (IOBDData)Activator.CreateInstance(dataType);
                            obdData.Load(message.Substring(4, message.Length - 4));

                            IDataEventManager dataEventManager;
                            if (_dataReceivedEventHandlers.TryGetValue(dataType, out dataEventManager))
                                dataEventManager.RaiseEvent(this, obdData, timestamp);
                        }
                    }
                }
        }

        protected virtual byte ResolvePid<T>()
            where T : class, IOBDData, new()
        {
            byte pid;
            if (!PidCache.TryGetValue(typeof(T), out pid))
            {
                T data = Activator.CreateInstance<T>();
                pid = data.PID;
                PidCache.Add(typeof(T), pid);
                DataTypeCache.Add(pid, typeof(T));
            }

            return pid;
        }

        public override void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool sendCloseProtocol)
        {
            try
            {
                if (sendCloseProtocol)
                {
                    SendCommand(ATCommand.CloseProtocol);
                    Thread.Sleep(500);
                }
            }
            catch { }

            _dataReceivedEventHandlers = null;

            base.Dispose();
        }

        public void SubscribeDataReceived<T>(DataReceivedEventHandler<T> eventHandler) where T : IOBDData
        {
            IDataEventManager eventManager;
            if (!_dataReceivedEventHandlers.TryGetValue(typeof(T), out eventManager))
                _dataReceivedEventHandlers.Add(typeof(T), (eventManager = new GenericDataEventManager<T>()));

            ((GenericDataEventManager<T>)eventManager).DataReceived += eventHandler;
        }

        public void UnsubscribeDataReceived<T>(DataReceivedEventHandler<T> eventHandler) where T : IOBDData
        {
            IDataEventManager eventManager;
            if (_dataReceivedEventHandlers.TryGetValue(typeof(T), out eventManager))
                ((GenericDataEventManager<T>)eventManager).DataReceived -= eventHandler;
        }

        #endregion
    }
}
