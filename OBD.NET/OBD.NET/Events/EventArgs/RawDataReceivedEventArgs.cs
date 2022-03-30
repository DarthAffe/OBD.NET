namespace OBD.NET.Events.EventArgs;

public class RawDataReceivedEventArgs
{
    #region Properties & Fields
        
    public string Data { get; }
    public DateTime Timestamp { get; }

    #endregion

    #region Constructors

    public RawDataReceivedEventArgs(string data, DateTime timestamp)
    {
        Data = data;
        Timestamp = timestamp;
    }

    #endregion
}