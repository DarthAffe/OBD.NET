namespace OBD.NET.OBDData
{
    public class AbsoluteEvapSystemVaporPressure : AbstractOBDData
    {
        #region Properties & Fields

        public double Pressure => ((256 * A) + B) / 200.0;

        #endregion

        #region Constructors

        public AbsoluteEvapSystemVaporPressure()
            : base(0x53, 2)
        { }

        #endregion
    }
}
