namespace OBD.NET.OBDData
{
    public class RelativeThrottlePosition : AbstractOBDData
    {
        #region Properties & Fields

        public double Position => A / 2.55;

        #endregion

        #region Constructors

        public RelativeThrottlePosition()
            : base(0x45, 1)
        { }

        #endregion
    }
}
