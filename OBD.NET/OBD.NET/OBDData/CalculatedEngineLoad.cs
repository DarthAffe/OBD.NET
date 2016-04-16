namespace OBD.NET.OBDData
{
    public class CalculatedEngineLoad : AbstractOBDData
    {
        #region Properties & Fields

        public double Load => A / 2.55;

        #endregion

        #region Constructors

        public CalculatedEngineLoad()
            : base(0x04, 1)
        { }

        #endregion
    }
}
