using System.Collections;
using System.Collections.Generic;

namespace OBD.NET.Common.OBDData
{
    public abstract class AbstractPidsSupported : AbstractOBDData
    {
        #region Properties & Fields

        public int[] SupportedPids
        {
            get
            {
                List<int> supportedPids = new List<int>();
                BitArray bitArray = new BitArray(new[] { D, C, B, A });

                for (int i = 0x01; i <= 0x20; i++)
                    if (bitArray.Get(bitArray.Length - i))
                        supportedPids.Add(PID + i);

                return supportedPids.ToArray();
            }
        }

        #endregion

        #region Constructors

        public AbstractPidsSupported(byte pid, int length) : base(pid, length)
        { }

        #endregion
    }
}
