namespace OBD.NET.OBDData
{
    public class FuelRailGaugePressure : AbstractOBDData
    {
        #region Properties & Fields

        public int Pressure => 10 * ((256 * A) + B);

        #endregion

        #region Constructors

        public FuelRailGaugePressure()
            : base(0x23, 2)
        { }

        #endregion
    }
}
