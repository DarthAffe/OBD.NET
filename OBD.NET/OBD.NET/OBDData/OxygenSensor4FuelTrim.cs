namespace OBD.NET.OBDData
{
    public class OxygenSensor4FuelTrim : AbstractOBDData
    {
        #region Properties & Fields

        public double Voltage => A / 200.0;
        public double ShortTermFuelTrim => (B / 1.28) - 100;
        public bool IsSensorUsed => B != 0xFF;

        #endregion

        #region Constructors

        public OxygenSensor4FuelTrim()
            : base(0x17, 2)
        { }

        #endregion
    }
}
