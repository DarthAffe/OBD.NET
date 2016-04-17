namespace OBD.NET.OBDData
{
    public class FuelRailAbsolutePressure : AbstractOBDData
    {
        #region Properties & Fields

        public int Pressure => 10 * ((256 * A) + B);

        #endregion

        #region Constructors

        public FuelRailAbsolutePressure()
            : base(0x59, 2)
        { }

        #endregion
    }
}
