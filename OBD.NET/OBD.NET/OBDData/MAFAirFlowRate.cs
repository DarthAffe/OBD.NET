namespace OBD.NET.OBDData
{
    public class MAFAirFlowRate : AbstractOBDData
    {
        #region Properties & Fields

        public double Rate => ((256 * A) + B) / 100.0;

        #endregion

        #region Constructors

        public MAFAirFlowRate()
            : base(0x10, 2)
        { }

        #endregion
    }
}
