namespace OBD.NET.OBDData
{
    public class AcceleratorPedalPositionF : AbstractOBDData
    {
        #region Properties & Fields

        public double Position => A / 2.55;

        #endregion

        #region Constructors

        public AcceleratorPedalPositionF()
            : base(0x4B, 1)
        { }

        #endregion
    }
}
