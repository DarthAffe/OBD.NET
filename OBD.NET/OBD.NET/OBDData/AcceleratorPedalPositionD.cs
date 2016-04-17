namespace OBD.NET.OBDData
{
    public class AcceleratorPedalPositionD : AbstractOBDData
    {
        #region Properties & Fields

        public double Position => A / 2.55;

        #endregion

        #region Constructors

        public AcceleratorPedalPositionD()
            : base(0x49, 1)
        { }

        #endregion
    }
}
