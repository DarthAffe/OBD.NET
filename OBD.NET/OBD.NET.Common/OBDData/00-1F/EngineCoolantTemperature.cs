using OBD.NET.Common.DataTypes;

namespace OBD.NET.Common.OBDData
{
    public class EngineCoolantTemperature : AbstractOBDData
    {
        #region Properties & Fields

        public DegreeCelsius Temperature => new DegreeCelsius(A - 40, -40, 215);

        #endregion

        #region Constructors

        public EngineCoolantTemperature()
            : base(0x05, 1)
        { }

        #endregion

        #region Methods

        public override string ToString() => Temperature.ToString();

        #endregion
    }
}
