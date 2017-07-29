using OBD.NET.Common.DataTypes;

namespace OBD.NET.Common.OBDData
{
    public class EvapSystemVaporPressure2 : AbstractOBDData
    {
        #region Properties & Fields

        public Pascal Pressure => new Pascal(((A * 256) + B) - 32767, -32767, 32768);

        #endregion

        #region Constructors

        public EvapSystemVaporPressure2()
            : base(0x54, 2)
        { }

        #endregion

        #region Methods

        public override string ToString() => Pressure.ToString();

        #endregion
    }
}
