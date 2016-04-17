namespace OBD.NET.OBDData
{
    public class FuelRailPressure : AbstractOBDData
    {
        #region Properties & Fields

        public double Pressure => 0.079 * ((256 * A) + B);

        #endregion

        #region Constructors

        public FuelRailPressure()
            : base(0x22, 2)
        { }

        #endregion
    }
}
