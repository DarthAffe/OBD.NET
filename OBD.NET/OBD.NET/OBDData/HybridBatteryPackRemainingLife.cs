namespace OBD.NET.OBDData
{
    public class HybridBatteryPackRemainingLife : AbstractOBDData
    {
        #region Properties & Fields

        public double RemainingLife => A / 2.55;

        #endregion

        #region Constructors

        public HybridBatteryPackRemainingLife()
            : base(0x5B, 1)
        { }

        #endregion
    }
}
