using System;
using System.Collections.Generic;
using System.Text;
using OBD.NET.Util;

namespace OBD.NET.Common.Devices
{
    public class CommandResult
    {
        public CommandResult()
        {
            WaitHandle = new AsyncManualResetEvent();
        }

        public object Result { get; set; }
        public AsyncManualResetEvent WaitHandle  { get; }
    }
}
