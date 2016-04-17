namespace OBD.NET.OBDData
{
    public class AbsoluteThrottlePositionB : AbstractOBDData
    {
        #region Properties & Fields

        public double Position => A / 2.55;

        #endregion

        #region Constructors

        public AbsoluteThrottlePositionB()
            : base(0x47, 1)
        { }

        #endregion
    }
}
