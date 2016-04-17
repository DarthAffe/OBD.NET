namespace OBD.NET.OBDData
{
    public class TimeSinceTroubleCodesCleared : AbstractOBDData
    {
        #region Properties & Fields

        public int Time => (256 * A) + B;

        #endregion

        #region Constructors

        public TimeSinceTroubleCodesCleared()
            : base(0x4E, 2)
        { }

        #endregion
    }
}
