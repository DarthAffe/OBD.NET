﻿using OBD.NET.DataTypes;

namespace OBD.NET.OBDData._60_7F;

public class IntakeAirTemperatureSensor : AbstractOBDData
{
    #region Properties & Fields

    public int SensorsSupported => A;
    public DegreeCelsius Bank1Sensor1 => new DegreeCelsius(B - 40, -40, 215);
    public DegreeCelsius Bank1Sensor2 => new DegreeCelsius(C - 40, -40, 215);
    public DegreeCelsius Bank1Sensor3 => new DegreeCelsius(D - 40, -40, 215);
    public DegreeCelsius Bank2Sensor1 => new DegreeCelsius(E - 40, -40, 215);
    public DegreeCelsius Bank2Sensor2 => new DegreeCelsius(RawData[5] - 40, -40, 215);
    public DegreeCelsius Bank2Sensor3 => new DegreeCelsius(RawData[6] - 40, -40, 215);

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