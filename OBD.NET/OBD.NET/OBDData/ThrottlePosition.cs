namespace OBD.NET.OBDData
{
    public class ThrottlePosition : AbstractOBDData
    {
        #region Properties & Fields

        public double Position => A / 2.55;

        #endregion

        #region Constructors

        public ThrottlePosition()
            : base(0x11, 1)
        { }

        #endregion
    }
}
