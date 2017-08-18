using OBD.NET.Common.DataTypes;

namespace OBD.NET.Common.OBDData
{
    public class LongTermFuelTrimBank1 : AbstractOBDData
    {
        #region Properties & Fields

        public Percent Trim => new Percent((A / 1.28) - 100, -100, 99.2);

        #endregion

        #region Constructors

        public LongTermFuelTrimBank1()
            : base(0x07, 1)
        { }

        #endregion
    }
}
