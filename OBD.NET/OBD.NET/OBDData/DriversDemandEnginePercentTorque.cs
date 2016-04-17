namespace OBD.NET.OBDData
{
    public class DriversDemandEnginePercentTorque : AbstractOBDData
    {
        #region Properties & Fields

        public int Torque => A - 125;

        #endregion

        #region Constructors

        public DriversDemandEnginePercentTorque()
            : base(0x61, 1)
        { }

        #endregion
    }
}
