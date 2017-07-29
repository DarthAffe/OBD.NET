using OBD.NET.Common.DataTypes;

namespace OBD.NET.Common.OBDData
{
    public class LongTermFuelTrimBank2 : AbstractOBDData
    {
        #region Properties & Fields

        public Percent Trim => new Percent((A / 1.28) - 100, -100, 99.2);

        #endregion

        #region Constructors

        public LongTermFuelTrimBank2()
            : base(0x09, 1)
        { }

        #endregion

        #region Methods

        public override string ToString() => Trim.ToString();

        #endregion
    }
}
