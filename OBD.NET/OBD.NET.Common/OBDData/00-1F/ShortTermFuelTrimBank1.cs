using OBD.NET.Common.DataTypes;

namespace OBD.NET.Common.OBDData
{
    public class ShortTermFuelTrimBank1 : AbstractOBDData
    {
        #region Properties & Fields

        public Percent Trim => new Percent((A / 1.28) - 100, -100, 99.2);

        #endregion

        #region Constructors

        public ShortTermFuelTrimBank1()
            : base(0x06, 1)
        { }

        #endregion
    }
}
