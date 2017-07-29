using OBD.NET.Common.DataTypes;

namespace OBD.NET.Common.OBDData
{
    public class EvapSystemVaporPressure : AbstractOBDData
    {
        #region Properties & Fields

        public Pascal Pressure => new Pascal(((256 * A) + B) / 4.0, -8192, 8191.75);

        #endregion

        #region Constructors

        public EvapSystemVaporPressure()
            : base(0x32, 2)
        { }

        #endregion

        #region Methods

        public override string ToString() => Pressure.ToString();

        #endregion
    }
}
