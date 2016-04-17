namespace OBD.NET.OBDData
{
    public class EnginePercentTorqueData : AbstractOBDData
    {
        #region Properties & Fields

        public int Idle => A - 125;
        public int EnginePoint1 => B - 125;
        public int EnginePoint2 => C - 125;
        public int EnginePoint3 => D - 125;
        public int EnginePoint4 => E - 125;

        #endregion

        #region Constructors

        public EnginePercentTorqueData()
            : base(0x64, 5)
        { }

        #endregion
    }
}
