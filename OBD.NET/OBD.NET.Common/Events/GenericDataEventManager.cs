using System;
using OBD.NET.Common.Devices;
using OBD.NET.Common.Events.EventArgs;
using OBD.NET.Common.OBDData;

namespace OBD.NET.Common.Events
{
    public class GenericDataEventManager<T> : IDataEventManager
        where T : IOBDData
    {
        #region Events

        internal event ELM327.DataReceivedEventHandler<T> DataReceived;

        #endregion

        #region Methods

        public void RaiseEvent(object sender, IOBDData data, DateTime timestamp) => DataReceived?.Invoke(sender, new DataReceivedEventArgs<T>((T)data, timestamp));

        #endregion
    }
}
