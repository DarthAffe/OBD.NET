namespace OBD.NET.OBDData
{
    public class ControlModuleVoltage : AbstractOBDData
    {
        #region Properties & Fields

        public double Voltage => ((256 * A) + B) / 1000.0;

        #endregion

        #region Constructors

        public ControlModuleVoltage()
            : base(0x42, 2)
        { }

        #endregion
    }
}
