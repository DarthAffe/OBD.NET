using OBD.NET.DataTypes;

namespace OBD.NET.OBDData
{
    public class HybridBatteryPackRemainingLife : AbstractOBDData
    {
        #region Properties & Fields

        public Percent RemainingLife => new Percent(A / 2.55, 0, 100);

        #endregion

        #region Constructors

        public HybridBatteryPackRemainingLife()
            : base(0x5B, 1)
        { }

        #endregion
    }
}
