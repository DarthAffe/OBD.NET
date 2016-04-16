namespace OBD.NET.OBDData
{
    public class LongTermFuelTrimBank1 : AbstractOBDData
    {
        #region Properties & Fields

        public double Trim => (A / 1.28) - 100;

        #endregion

        #region Constructors

        public LongTermFuelTrimBank1()
            : base(0x07, 1)
        { }

        #endregion
    }
}
