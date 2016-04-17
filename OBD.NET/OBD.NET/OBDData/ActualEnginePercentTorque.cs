namespace OBD.NET.OBDData
{
    public class ActualEnginePercentTorque : AbstractOBDData
    {
        #region Properties & Fields

        public int Torque => A - 125;

        #endregion

        #region Constructors

        public ActualEnginePercentTorque()
            : base(0x62, 1)
        { }

        #endregion
    }
}
