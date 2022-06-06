using System;
using OBD.NET.OBDData;

namespace OBD.NET.Events;

public interface IDataEventManager
{
    void RaiseEvent(object sender, IOBDData data, DateTime timestamp);
}