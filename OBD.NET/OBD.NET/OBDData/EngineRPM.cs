namespace OBD.NET.OBDData
{
    public class EngineRPM : AbstractOBDData
    {
        #region Properties & Fields

        public double RPM => ((256 * A) + B) / 4.0;

        #endregion

        #region Constructors

        public EngineRPM()
            : base(0x0C, 2)
        { }

        #endregion
    }
}
