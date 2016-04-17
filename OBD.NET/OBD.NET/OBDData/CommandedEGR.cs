namespace OBD.NET.OBDData
{
    public class CommandedEGR : AbstractOBDData
    {
        #region Properties & Fields

        public double EGR => A / 2.55;

        #endregion

        #region Constructors

        public CommandedEGR()
            : base(0x2C, 1)
        { }

        #endregion
    }
}
