using System.Collections.Generic;

namespace OBD.NET.OBDData
{
    public class PidsSupported01_20 : AbstractOBDData
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
                                supportedPids.Add(i);
                            break;
                        case 1:
                            if ((A << (15 - i)) != 0)
                                supportedPids.Add(i);
                            break;
                        case 2:
                            if ((A << (23 - i)) != 0)
                                supportedPids.Add(i);
                            break;
                        case 3:
                            if ((A << (31 - i)) != 0)
                                supportedPids.Add(i);
                            break;
                    }
                return supportedPids.ToArray();
            }
        }

        #endregion

        #region Constructors

        public PidsSupported01_20()
            : base(0x00, 4)
        { }

        #endregion
    }
}
