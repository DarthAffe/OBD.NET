using System;
using OBD.NET.Common.OBDData;

namespace OBD.NET.Common.Events
{
    public interface IDataEventManager
    {
        void RaiseEvent(object sender, IOBDData data, DateTime timestamp);
    }
}
