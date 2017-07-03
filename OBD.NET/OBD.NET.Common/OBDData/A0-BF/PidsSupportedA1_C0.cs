using System.Collections.Generic;

namespace OBD.NET.OBDData
{
    public class PidsSupportedA1_C0 : AbstractOBDData
    {
        #region Properties & Fields

        public int[] SupportedPids
        {
            get
            {
                List<int> supportedPids = new List<int>();
                for (int i = 0x01; i < 0x20; i++)
                    switch ((int)(i / 8.0))
                    {
                        case 0:
                            if ((A << (7 - i)) != 0)
                                supportedPids.Add(PID + i);
                            break;
                        case 1:
                            if ((B << (15 - i)) != 0)
                                supportedPids.Add(PID + i);
                            break;
                        case 2:
                            if ((C << (23 - i)) != 0)
                                supportedPids.Add(PID + i);
                            break;
                        case 3:
                            if ((D << (31 - i)) != 0)
                                supportedPids.Add(PID + i);
                            break;
                    }
                return supportedPids.ToArray();
            }
        }

        #endregion

        #region Constructors

        public PidsSupportedA1_C0()
            : base(0xA0, 4)
        { }

        #endregion
    }
}
