using System.Collections.Generic;

namespace OBD.NET.Common.OBDData
{
    public class PidsSupportedC1_E0 : AbstractOBDData
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

        public PidsSupportedC1_E0()
            : base(0xC0, 4)
        { }

        #endregion

        #region Methods

        public override string ToString() => string.Join(",", SupportedPids);

        #endregion
    }
}
