using OBD.NET.Common.DataTypes;

namespace OBD.NET.Common.OBDData
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

        #region Methods

        public override string ToString() => Pressure.ToString();

        #endregion
    }
}
