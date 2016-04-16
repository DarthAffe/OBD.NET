namespace OBD.NET.OBDData
{
    public class TimingAdvance : AbstractOBDData
    {
        #region Properties & Fields

        public double Timing => (A / 2.0) - 64;

        #endregion

        #region Constructors

        public TimingAdvance()
            : base(0x0E, 1)
        { }

        #endregion
    }
}
