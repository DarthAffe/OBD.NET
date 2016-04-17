namespace OBD.NET.OBDData
{
    public class AbsoluteLoadValue : AbstractOBDData
    {
        #region Properties & Fields

        public double Load => ((256 * A) + B) / 2.55;

        #endregion

        #region Constructors

        public AbsoluteLoadValue()
            : base(0x43, 2)
        { }

        #endregion
    }
}
