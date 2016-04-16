namespace OBD.NET.OBDData
{
    public class OxygenSensor8 : AbstractOBDData
    {
        #region Properties & Fields

        public double Voltage => A / 200.0;
        public double ShortTermFuelTrim => (B / 1.28) - 100;
        public bool IsSensorUsed => B != 0xFF;

        #endregion

        #region Constructors

        public OxygenSensor8()
            : base(0x1B, 2)
        { }

        #endregion
    }
}
