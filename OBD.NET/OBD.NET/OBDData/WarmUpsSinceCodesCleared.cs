namespace OBD.NET.OBDData
{
    public class WarmUpsSinceCodesCleared : AbstractOBDData
    {
        #region Properties & Fields

        public int WarmUps => A;

        #endregion

        #region Constructors

        public WarmUpsSinceCodesCleared()
            : base(0x30, 1)
        { }

        #endregion
    }
}
