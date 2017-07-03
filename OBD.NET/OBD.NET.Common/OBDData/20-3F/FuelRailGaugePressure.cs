using OBD.NET.DataTypes;

namespace OBD.NET.OBDData
{
    public class FuelRailGaugePressure : AbstractOBDData
    {
        #region Properties & Fields

        public Kilopascal Pressure => new Kilopascal(10 * ((256 * A) + B), 0, 655350);

        #endregion

        #region Constructors

        public FuelRailGaugePressure()
            : base(0x23, 2)
        { }

        #endregion
    }
}
