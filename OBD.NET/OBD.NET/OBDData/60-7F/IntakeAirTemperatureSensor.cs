using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class IntakeAirTemperatureSensor : AbstractOBDData
{
    #region Properties & Fields

    public int SensorsSupported => A;
    public DegreeCelsius Bank1Sensor1 => new(B - 40, -40, 215);
    public DegreeCelsius Bank1Sensor2 => new(C - 40, -40, 215);
    public DegreeCelsius Bank1Sensor3 => new(D - 40, -40, 215);
    public DegreeCelsius Bank2Sensor1 => new(E - 40, -40, 215);
    public DegreeCelsius Bank2Sensor2 => new(RawData[5] - 40, -40, 215);
    public DegreeCelsius Bank2Sensor3 => new(RawData[6] - 40, -40, 215);

    #endregion

    #region Constructors

    public IntakeAirTemperatureSensor()
        : base(0x68, 7)
    { }

    #endregion

    #region Methods

    public override string ToString() => Bank1Sensor1.ToString();

    #endregion
}