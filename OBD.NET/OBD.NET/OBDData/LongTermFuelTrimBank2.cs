namespace OBD.NET.OBDData
{
    public class LongTermFuelTrimBank2 : AbstractOBDData
    {
        #region Properties & Fields

        public double Trim => (A / 1.28) - 100;

        #endregion

        #region Constructors

        public LongTermFuelTrimBank2()
            : base(0x09, 1)
        { }

        #endregion
    }
}
