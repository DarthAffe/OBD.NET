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

        protected override string ExpectedNoData => @"(NO DATA)|(SEARCHING)|(STOP)|\?";

        #endregion

        #region Events 

        public delegate void DataReceivedEventHandler<T>(object sender, DataReceivedEventArgs<T> args) where T : IOBDData;

        public delegate void RawDataReceivedEventHandler(object sender, RawDataReceivedEventArgs args);
        public event RawDataReceivedEventHandler RawDataReceived;

        #endregion

        #region Constructors

        public ELM327(SerialConnection connection, IOBDLogger logger = null)
            : base(connection, logger: logger)
        { }

        #endregion

        #region Methods

        public override void Initialize()
        {
            base.Initialize();

            Logger?.WriteLine("Initializing ...", OBDLogLevel.Debug);
            int repeats = 3;
            bool repeat = true;
            while (repeat)
            {
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

                    repeat = false;
                }
                // DarthAffe 21.02.2017: This seems to happen sometimes, i don't know why - just retry.
                catch (TimeoutException)
                {
                    if (repeats > 0)
                    {
                        Logger?.WriteLine("Timout while initializing ... retry!", OBDLogLevel.Debug);
                        repeats--;
                    }
                    else
                    {
                        Logger?.WriteLine("Failed to initialize the device!", OBDLogLevel.Error);
                        throw;
                    }
                }
            }

            Thread.Sleep(1000);
        }

        public virtual void SendCommand(ATCommand command)
        {
            SendCommand(command.Command, command.ExpectedResult);
        }

        public virtual T RequestData<T>()
            where T : class, IOBDData, new()
        {
            Logger?.WriteLine("Requesting Type " + typeof(T).Name + " ...", OBDLogLevel.Debug);

            byte pid;
            if (!PidCache.TryGetValue(typeof(T), out pid))
            {
                T data = Activator.CreateInstance<T>();
                pid = data.PID;
                PidCache.Add(typeof(T), pid);
                DataTypeCache.Add(pid, typeof(T));
            }
            return RequestData(pid) as T;
        }

        public virtual IOBDData RequestData(byte pid)
        {
            Logger?.WriteLine("Requesting PID " + pid.ToString("X2") + " ...", OBDLogLevel.Debug);
            string result = SendCommand(((byte)Mode).ToString("X2") + pid.ToString("X2"), "4.*");
            Logger?.WriteLine("Result for PID " + pid.ToString("X2") + ": " + result, OBDLogLevel.Debug);
            return ProcessData(result);
        }

        protected virtual IOBDData ProcessData(string data)
        {
            if (data == null) return null;

            DateTime timestamp = DateTime.Now;

            RawDataReceived?.Invoke(this, new RawDataReceivedEventArgs(data, timestamp));

            if (data.Length > 4)
                if (data[0] == '4')
                {
                    byte mode = (byte)data[1].GetHexVal();
                    if (mode == (byte)Mode)
                    {
                        byte pid = (byte)data.Substring(2, 2).GetHexVal();
                        Type dataType;
                        if (DataTypeCache.TryGetValue(pid, out dataType))
                        {
                            IOBDData obdData = (IOBDData)Activator.CreateInstance(dataType);
                            obdData.Load(data.Substring(4, data.Length - 4));

                            IDataEventManager dataEventManager;
                            if (_dataReceivedEventHandlers.TryGetValue(dataType, out dataEventManager))
                                dataEventManager.RaiseEvent(this, obdData, timestamp);

                            return obdData;
                        }
                    }
                }

            return null;
        }

        public override void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool sendCloseProtocol)
        {
            if (sendCloseProtocol)
            {
                SendCommand(ATCommand.CloseProtocol);
                Thread.Sleep(500);
            }

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
