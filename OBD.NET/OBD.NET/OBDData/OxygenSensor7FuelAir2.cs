namespace OBD.NET.OBDData
{
    public class OxygenSensor7FuelAir2 : AbstractOBDData
    {
        #region Properties & Fields

        public double FuelAirEquivalenceRatio => (2.0 / 25536.0) * ((256 * A) + B);
        public double Current => C + (D / 256.0) - 128;

        #endregion

        #region Constructors

        public OxygenSensor7FuelAir2()
            : base(0x3A, 4)
        { }

        #endregion
    }
}
