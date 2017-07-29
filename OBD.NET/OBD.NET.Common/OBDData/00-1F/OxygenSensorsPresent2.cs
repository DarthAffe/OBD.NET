using System;

namespace OBD.NET.Common.OBDData
{
    public class OxygenSensorPresent2 : AbstractOBDData
    {
        #region Properties & Fields

        public bool IsSensor1Present => (A & (1 << 0)) != 0;
        public bool IsSensor2Present => (A & (1 << 1)) != 0;
        public bool IsSensor3Present => (A & (1 << 2)) != 0;
        public bool IsSensor4Present => (A & (1 << 3)) != 0;
        public bool IsSensor5Present => (A & (1 << 4)) != 0;
        public bool IsSensor6Present => (A & (1 << 5)) != 0;
        public bool IsSensor7Present => (A & (1 << 6)) != 0;
        public bool IsSensor8Present => (A & (1 << 7)) != 0;

        #endregion

        #region Constructors

        public OxygenSensorPresent2()
            : base(0x1D, 1)
        { }

        #endregion

        #region Methods

        public override string ToString() => Convert.ToString(A, 2);

        #endregion
    }
}
