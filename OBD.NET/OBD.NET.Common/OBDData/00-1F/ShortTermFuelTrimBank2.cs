using OBD.NET.Common.DataTypes;

namespace OBD.NET.Common.OBDData
{
    public class ShortTermFuelTrimBank2 : AbstractOBDData
    {
        #region Properties & Fields

        public Percent Trim => new Percent((A / 1.28) - 100, -100, 99.2);

        #endregion

        #region Constructors

        public ShortTermFuelTrimBank2()
            : base(0x08, 1)
        { }

        #endregion

        #region Methods

        public override string ToString() => Trim.ToString();

        #endregion
    }
}
