namespace OBD.NET.OBDData
{
    public class EvapSystemVaporPressure2 : AbstractOBDData
    {
        #region Properties & Fields

        public int Pressure => ((A * 256) + B) - 32767;

        #endregion

        #region Constructors

        public EvapSystemVaporPressure2()
            : base(0x54, 2)
        { }

        #endregion
    }
}
