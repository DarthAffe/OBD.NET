namespace OBD.NET.OBDData
{
    public class FuelAirCommandedEquivalenceRatio : AbstractOBDData
    {
        #region Properties & Fields

        public double Ratio => (2.0 / 65536.0) * ((256 * A) + B);

        #endregion

        #region Constructors

        public FuelAirCommandedEquivalenceRatio()
            : base(0x44, 2)
        { }

        #endregion
    }
}
