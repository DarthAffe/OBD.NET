namespace OBD.NET.OBDData
{
    public class ShortTermFuelTrimBank1 : AbstractOBDData
    {
        #region Properties & Fields

        public double Trim => (A / 1.28) - 100;

        #endregion

        #region Constructors

        public ShortTermFuelTrimBank1()
            : base(0x06, 1)
        { }

        #endregion
    }
}
