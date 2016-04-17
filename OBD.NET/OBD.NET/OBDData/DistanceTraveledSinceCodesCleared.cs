namespace OBD.NET.OBDData
{
    public class DistanceTraveledSinceCodesCleared : AbstractOBDData
    {
        #region Properties & Fields

        public int Distance => (256 * A) + B;

        #endregion

        #region Constructors

        public DistanceTraveledSinceCodesCleared()
            : base(0x31, 2)
        { }

        #endregion
    }
}
