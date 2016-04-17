namespace OBD.NET.OBDData
{
    public class AcceleratorPedalPositionE : AbstractOBDData
    {
        #region Properties & Fields

        public double Position => A / 2.55;

        #endregion

        #region Constructors

        public AcceleratorPedalPositionE()
            : base(0x4A, 1)
        { }

        #endregion
    }
}
