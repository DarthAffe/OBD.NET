using System;
using System.Collections.Generic;
using System.Text;

namespace OBD.NET.Common.Communication.EventArgs
{
    /// <summary>
    /// Event args on receiving serial data
    /// </summary>
    public class DataReceivedEventArgs:System.EventArgs
    {
        public DataReceivedEventArgs(int count, byte[] data)
        {
            Count = count;
            Data = data;
        }

        public int Count { get; private set; }
        public byte[] Data { get; private set; }
    }
}
