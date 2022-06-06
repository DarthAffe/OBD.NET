﻿using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class CatalystTemperatureBank2Sensor1 : AbstractOBDData
{
    #region Properties & Fields

    public DegreeCelsius Temperature => new((((256 * A) + B) / 10.0) - 40, -40, 6513.5);

    #endregion

    #region Constructors

    public CatalystTemperatureBank2Sensor1()
        : base(0x3E, 2)
    { }

    #endregion

    #region Methods

    public override string ToString() => Temperature.ToString();

    #endregion
}