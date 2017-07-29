using OBD.NET.Common.DataTypes;

namespace OBD.NET.Common.OBDData
{
    public class FuelPressure : AbstractOBDData
    {
        #region Properties & Fields

        public Kilopascal Pressure => new Kilopascal(3 * A, 0, 765);

        #endregion

        #region Constructors

        public FuelPressure()
            : base(0x0A, 1)
        { }

        #endregion

        #region Methods

        public override string ToString() => Pressure.ToString();

        #endregion
    }
}
