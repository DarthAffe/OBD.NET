namespace OBD.NET.OBDData
{
    public class AbsoluteThrottlePositionC : AbstractOBDData
    {
        #region Properties & Fields

        public double Position => A / 2.55;

        #endregion

        #region Constructors

        public AbsoluteThrottlePositionC()
            : base(0x48, 1)
        { }

        #endregion
    }
}
