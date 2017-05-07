using OBD.NET.DataTypes;

namespace OBD.NET.OBDData
{
    public class AmbientAirTemperature : AbstractOBDData
    {
        #region Properties & Fields

        public DegreeCelsius Temperature => new DegreeCelsius(A - 40, -40, 215);

        #endregion

        #region Constructors

        public AmbientAirTemperature()
            : base(0x46, 1)
        { }

        #endregion
    }
}
