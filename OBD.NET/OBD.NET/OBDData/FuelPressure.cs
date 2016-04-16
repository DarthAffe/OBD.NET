namespace OBD.NET.OBDData
{
    public class FuelPressure : AbstractOBDData
    {
        #region Properties & Fields

        public int Pressure => 3 * A;

        #endregion

        #region Constructors

        public FuelPressure()
            : base(0x0A, 1)
        { }

        #endregion
    }
}
