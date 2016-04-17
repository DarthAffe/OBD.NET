namespace OBD.NET.OBDData
{
    public class EngineFuelRate : AbstractOBDData
    {
        #region Properties & Fields

        public double FuelRate => ((256 * A) + B) / 20.0;

        #endregion

        #region Constructors

        public EngineFuelRate()
            : base(0x5E, 2)
        { }

        #endregion
    }
}
