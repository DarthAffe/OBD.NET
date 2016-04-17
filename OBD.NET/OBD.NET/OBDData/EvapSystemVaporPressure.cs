namespace OBD.NET.OBDData
{
    public class EvapSystemVaporPressure : AbstractOBDData
    {
        #region Properties & Fields

        public double Pressure => ((256 * A) + B) / 4.0;

        #endregion

        #region Constructors

        public EvapSystemVaporPressure()
            : base(0x32, 2)
        { }

        #endregion
    }
}
