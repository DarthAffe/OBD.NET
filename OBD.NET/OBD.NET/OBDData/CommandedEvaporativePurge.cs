namespace OBD.NET.OBDData
{
    public class CommandedEvaporativePurge : AbstractOBDData
    {
        #region Properties & Fields

        public double Purge => A / 2.55;

        #endregion

        #region Constructors

        public CommandedEvaporativePurge()
            : base(0x2E, 1)
        { }

        #endregion
    }
}
