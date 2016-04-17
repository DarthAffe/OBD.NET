namespace OBD.NET.OBDData
{
    public class TimeRunWithMILOn : AbstractOBDData
    {
        #region Properties & Fields

        public int Time => (256 * A) + B;

        #endregion

        #region Constructors

        public TimeRunWithMILOn()
            : base(0x4D, 2)
        { }

        #endregion
    }
}
