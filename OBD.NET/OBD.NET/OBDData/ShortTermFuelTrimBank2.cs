namespace OBD.NET.OBDData
{
    public class ShortTermFuelTrimBank2 : AbstractOBDData
    {
        #region Properties & Fields

        public double Trim => (A / 1.28) - 100;

        #endregion

        #region Constructors

        public ShortTermFuelTrimBank2()
            : base(0x08, 1)
        { }

        #endregion
    }
}
