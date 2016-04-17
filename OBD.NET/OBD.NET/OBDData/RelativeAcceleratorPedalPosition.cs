namespace OBD.NET.OBDData
{
    public class RelativeAcceleratorPedalPosition : AbstractOBDData
    {
        #region Properties & Fields

        public double PedalPosition => A / 2.55;

        #endregion

        #region Constructors

        public RelativeAcceleratorPedalPosition()
            : base(0x5A, 1)
        { }

        #endregion
    }
}
