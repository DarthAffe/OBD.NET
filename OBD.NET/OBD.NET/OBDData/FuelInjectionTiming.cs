namespace OBD.NET.OBDData
{
    public class FuelInjectionTiming : AbstractOBDData
    {
        #region Properties & Fields

        public double Timing => (((256 * A) + B) / 128.0) - 210;

        #endregion

        #region Constructors

        public FuelInjectionTiming()
            : base(0x5D, 2)
        { }

        #endregion
    }
}
