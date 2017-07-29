using System;

namespace OBD.NET.Common.Events.EventArgs
{
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
}
