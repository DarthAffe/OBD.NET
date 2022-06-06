﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using OBD.NET.Commands;
using OBD.NET.Communication;
using OBD.NET.Enums;
using OBD.NET.Events;
using OBD.NET.Extensions;
using OBD.NET.Logging;
using OBD.NET.OBDData;

namespace OBD.NET.Devices;

public class ELM327 : SerialDevice
{
    #region Properties & Fields

    protected readonly Dictionary<Type, IDataEventManager> DataReceivedEventHandlers = new();

    protected static Dictionary<Type, byte> PidCache { get; } = new();
    protected static Dictionary<byte, Type> DataTypeCache { get; } = new();

    protected Mode Mode { get; set; } = Mode.ShowCurrentData; //TODO DarthAffe 26.06.2016: Implement different modes

    protected string MessageChunk { get; set; } = string.Empty;

    #endregion

    #region Events

    public delegate void DataReceivedEventHandler<T>(object sender, DataReceivedEventArgs<T> args) where T : IOBDData;

    public delegate void RawDataReceivedEventHandler(object sender, RawDataReceivedEventArgs args);
    public event RawDataReceivedEventHandler? RawDataReceived;

    #endregion

    #region Constructors

    public ELM327(ISerialConnection connection, IOBDLogger? logger = null)
        : base(connection, logger: logger)
    { }

    #endregion

    #region Methods

    public override async Task InitializeAsync()
    {
        await base.InitializeAsync();
        InternalInitialize();
    }

    public override void Initialize()
    {
        base.Initialize();
        InternalInitialize();
    }

    private void InternalInitialize()
    {
        Logger?.WriteLine("Initializing ...", OBDLogLevel.Debug);

        try
        {
            Logger?.WriteLine("Resetting Device ...", OBDLogLevel.Debug);
            SendCommand(ATCommand.ResetDevice);

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

            WaitQueue();
        }
        // DarthAffe 21.02.2017: This seems to happen sometimes, i don't know why - just retry.
        catch
        {
            Logger?.WriteLine("Failed to initialize the device!", OBDLogLevel.Error);
            throw;
        }
    }

    /// <summary>
    /// Sends the AT command.
    /// </summary>
    /// <param name="command">The command.</param>
    public virtual void SendCommand(ATCommand command) => SendCommand(command.Command);

    /// <summary>
    /// Requests the data and calls the handler
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public virtual void RequestData<T>()
        where T : class, IOBDData, new()
    {
        Logger?.WriteLine("Requesting Type " + typeof(T).Name + " ...", OBDLogLevel.Debug);

        byte pid = ResolvePid<T>();
        RequestData(pid);
    }

    /// <summary>
    /// Request data based on a pid
    /// </summary>
    /// <param name="pid">The pid of the requested data</param>
    public virtual void RequestData(byte pid)
    {
        Logger?.WriteLine("Requesting PID " + pid.ToString("X2") + " ...", OBDLogLevel.Debug);
        SendCommand(((byte)Mode).ToString("X2") + pid.ToString("X2"));
    }

    /// <summary>
    /// Requests the data asynchronous and return the data when available
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public virtual async Task<T?> RequestDataAsync<T>()
        where T : class, IOBDData, new()
    {
        Logger?.WriteLine("Requesting Type " + typeof(T).Name + " ...", OBDLogLevel.Debug);
        byte pid = ResolvePid<T>();
        return await RequestDataAsync(pid) as T;
    }

    /// <summary>
    /// Requests the data asynchronous and return the data when available
    /// </summary>
    /// <returns></returns>
    public virtual async Task<IOBDData?> RequestDataAsync(Type type)
    {
        Logger?.WriteLine("Requesting Type " + type.Name + " ...", OBDLogLevel.Debug);
        byte pid = ResolvePid(type);
        return await RequestDataAsync(pid) as IOBDData;
    }

    /// <summary>
    /// Request data based on a pid
    /// </summary>
    /// <param name="pid">The pid of the requested data</param>
    public virtual async Task<object?> RequestDataAsync(byte pid)
    {
        Logger?.WriteLine("Requesting PID " + pid.ToString("X2") + " ...", OBDLogLevel.Debug);
        CommandResult result = SendCommand(((byte)Mode).ToString("X2") + pid.ToString("X2"));

        await result.WaitHandle.WaitAsync();
        return result.Result;
    }

    protected override object? ProcessMessage(string message)
    {
        DateTime timestamp = DateTime.Now;

        RawDataReceived?.Invoke(this, new RawDataReceivedEventArgs(message, timestamp));

        if (message.Length > 4)
        {
            // DarthAffe 15.08.2020: Splitted messages are prefixed with 0: (first chunk) and 1: (second chunk)
            // DarthAffe 15.08.2020: They also seem to be always preceded by a '009'-message, but since that's to short to be processed it should be safe to ignore.
            // DarthAffe 15.08.2020: Since that behavior isn't really documented (at least I wasn't able to find it) that's all trial and error and might not work for all pids with long results.
            if (message[1] == ':')
            {
                if (message[0] == '0')
                    MessageChunk = message.Substring(2, message.Length - 2);
                else if (message[0] == '1')
                {
                    string fullMessage = MessageChunk + message.Substring(2, message.Length - 2);
                    MessageChunk = string.Empty;
                    return ProcessMessage(fullMessage);
                }
            }
            else if (message[0] == '4')
            {
                byte mode = (byte)message[1].GetHexVal();
                if (mode == (byte)Mode)
                {
                    byte pid = (byte)message.Substring(2, 2).GetHexVal();
                    if (DataTypeCache.TryGetValue(pid, out Type? dataType))
                    {
                        IOBDData obdData = (IOBDData)Activator.CreateInstance(dataType)!;
                        obdData.Load(message.Substring(4, message.Length - 4));

                        if (DataReceivedEventHandlers.TryGetValue(dataType, out IDataEventManager? dataEventManager))
                            dataEventManager.RaiseEvent(this, obdData, timestamp);

                        if (DataReceivedEventHandlers.TryGetValue(typeof(IOBDData), out IDataEventManager? genericDataEventManager))
                            genericDataEventManager.RaiseEvent(this, obdData, timestamp);

                        return obdData;
                    }
                }
            }
        }
        return null;
    }

    protected virtual byte ResolvePid<T>()
        where T : class, IOBDData, new()
        => ResolvePid(typeof(T));

    protected virtual byte ResolvePid(Type type)
    {
        if (!PidCache.TryGetValue(type, out byte pid))
            pid = AddToPidCache(type);

        return pid;
    }

    public virtual byte AddToPidCache<T>()
        where T : class, IOBDData, new() => AddToPidCache(typeof(T));

    protected virtual byte AddToPidCache(Type obdDataType)
    {
        if (Activator.CreateInstance(obdDataType) is not IOBDData data) throw new ArgumentException("Has to implement IOBDData", nameof(obdDataType));

        byte pid = data.PID;

        PidCache.Add(obdDataType, pid);
        DataTypeCache.Add(pid, obdDataType);

        return pid;
    }

    /// <summary>
    /// YOU SHOULDN'T NEED THIS METHOD!
    ///
    /// You should only use this method if you're requesting data by pid instead of the <see cref="RequestData{T}"/>-method.
    ///
    /// Initializes the PID-Cache with all IOBDData-Types contained in OBD.NET.
    /// You can add additional ones with <see cref="AddToPidCache{T}"/>.
    /// </summary>
    public virtual void InitializePidCache()
    {
        TypeInfo iobdDataInfo = typeof(IOBDData).GetTypeInfo();
        foreach (TypeInfo obdDataType in iobdDataInfo.Assembly.DefinedTypes.Where(t => t.IsClass && !t.IsAbstract && iobdDataInfo.IsAssignableFrom(t)))
            AddToPidCache(obdDataType.AsType());
    }

    public override void Dispose() => Dispose(true);

    public void Dispose(bool sendCloseProtocol)
    {
        try
        {
            if (sendCloseProtocol)
                SendCommand(ATCommand.CloseProtocol);
        }
        catch { /* Well at least we tried ... */ }

        DataReceivedEventHandlers.Clear();

        base.Dispose();
    }

    public void SubscribeDataReceived<T>(DataReceivedEventHandler<T> eventHandler) where T : IOBDData
    {
        if (!DataReceivedEventHandlers.TryGetValue(typeof(T), out IDataEventManager? eventManager))
            DataReceivedEventHandlers.Add(typeof(T), (eventManager = new GenericDataEventManager<T>()));

        ((GenericDataEventManager<T>)eventManager).DataReceived += eventHandler;
    }

    public void UnsubscribeDataReceived<T>(DataReceivedEventHandler<T> eventHandler) where T : IOBDData
    {
        if (DataReceivedEventHandlers.TryGetValue(typeof(T), out IDataEventManager? eventManager))
            ((GenericDataEventManager<T>)eventManager).DataReceived -= eventHandler;
    }

    #endregion
}