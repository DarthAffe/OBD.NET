namespace OBD.NET.OBDData
{
    public class RunTimeSinceEngineStart : AbstractOBDData
    {
        #region Properties & Fields

        public int Runtime => (256 * A) + B;

        #endregion

        #region Constructors

        public RunTimeSinceEngineStart()
            : base(0x1F, 2)
        { }

        #endregion
    }
}
