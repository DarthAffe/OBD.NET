using OBD.NET.Common.DataTypes;

namespace OBD.NET.Common.OBDData
{
    public class EngineCoolantTemperatureSensor : AbstractOBDData
    {
        #region Properties & Fields

        public int SensorsSupported => A;
        public DegreeCelsius Sensor1 => new DegreeCelsius(B - 40, -40, 215);
        public DegreeCelsius Sensor2 => new DegreeCelsius(C - 40, -40, 215);

        #endregion

        #region Constructors

        public EngineCoolantTemperatureSensor()
            : base(0x67, 3)
        { }

        #endregion

        #region Methods

        public override string ToString() => Sensor1.ToString();

        #endregion
    }
}
