namespace OBD.NET.OBDData
{
    public class FuelTankLevelInput : AbstractOBDData
    {
        #region Properties & Fields

        public double Level => A / 2.55;

        #endregion

        #region Constructors

        public FuelTankLevelInput()
            : base(0x2F, 1)
        { }

        #endregion
    }
}
