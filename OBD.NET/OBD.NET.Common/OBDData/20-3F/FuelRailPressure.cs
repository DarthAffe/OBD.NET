using OBD.NET.DataTypes;

namespace OBD.NET.OBDData
{
    public class FuelRailPressure : AbstractOBDData
    {
        #region Properties & Fields

        public Kilopascal Pressure => new Kilopascal(0.079 * ((256 * A) + B), 0, 5177.265);

        #endregion

        #region Constructors

        public FuelRailPressure()
            : base(0x22, 2)
        { }

        #endregion
    }
}
