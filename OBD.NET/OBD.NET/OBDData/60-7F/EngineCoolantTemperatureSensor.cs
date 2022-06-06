using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class EngineCoolantTemperatureSensor : AbstractOBDData
{
    #region Properties & Fields

    public int SensorsSupported => A;
    public DegreeCelsius Sensor1 => new(B - 40, -40, 215);
    public DegreeCelsius Sensor2 => new(C - 40, -40, 215);

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