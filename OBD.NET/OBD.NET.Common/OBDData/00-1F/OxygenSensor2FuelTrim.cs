using OBD.NET.Common.DataTypes;

namespace OBD.NET.Common.OBDData
{
    public class OxygenSensor2FuelTrim : AbstractOBDData
    {
        #region Properties & Fields

        public Volt Voltage => new Volt(A / 200.0, 0, 1.275);
        public Percent ShortTermFuelTrim => new Percent((B / 1.28) - 100, -100, 99.2);
        public bool IsSensorUsed => B != 0xFF;

        #endregion

        #region Constructors

        public OxygenSensor2FuelTrim()
            : base(0x15, 2)
        { }

        #endregion

        #region Methods

        public override string ToString() => ShortTermFuelTrim.ToString();

        #endregion
    }
}
