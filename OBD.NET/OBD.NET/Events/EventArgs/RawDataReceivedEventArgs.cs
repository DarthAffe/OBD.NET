using System;

namespace OBD.NET.Events;

public class RawDataReceivedEventArgs
{
    #region Properties & Fields
        
    public string Data { get; }
    public DateTime Timestamp { get; }

    #endregion

    #region Constructors

    public RawDataReceivedEventArgs(string data, DateTime timestamp)
    {
        this.Data = data;
        this.Timestamp = timestamp;
    }

    #endregion
}