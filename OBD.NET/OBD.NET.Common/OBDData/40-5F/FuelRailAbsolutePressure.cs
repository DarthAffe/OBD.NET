using OBD.NET.DataTypes;

namespace OBD.NET.OBDData
{
    public class FuelRailAbsolutePressure : AbstractOBDData
    {
        #region Properties & Fields

        public Kilopascal Pressure => new Kilopascal(10 * ((256 * A) + B), 0, 655350);

        #endregion

        #region Constructors

        public FuelRailAbsolutePressure()
            : base(0x59, 2)
        { }

        #endregion
    }
}
