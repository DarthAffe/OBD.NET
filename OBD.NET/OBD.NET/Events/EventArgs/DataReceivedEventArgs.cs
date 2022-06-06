using System;
using OBD.NET.OBDData;

namespace OBD.NET.Events;

public class DataReceivedEventArgs<T> where T : IOBDData
{
    #region Properties & Fields

    public T Data { get; }
    public DateTime Timestamp { get; }

    #endregion

    #region Constructors

    public DataReceivedEventArgs(T data, DateTime timestamp)
    {
        this.Data = data;
        this.Timestamp = timestamp;
    }

    #endregion
}