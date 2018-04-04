using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBD.NET.Common.OBDData
{
    public abstract class AbstractPidsSupported : AbstractOBDData
    {
        public AbstractPidsSupported(byte pid, int length) : base(pid, length)
        {

        }

        public int[] SupportedPids
        {
            get
            {
                List<int> supportedPids = new List<int>();
                byte[] byteArray = new byte[] { D, C, B, A };
                var bitArray = new BitArray(byteArray);
                for (int i = 0x01; i <= 0x20; i++)
                {
                    if (bitArray.Get(bitArray.Length - i))
                    {
                        supportedPids.Add(PID + i);
                    }
                }
                return supportedPids.ToArray();
            }
        }
    }
}

