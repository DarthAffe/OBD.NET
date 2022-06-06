﻿using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class EngineOilTemperature : AbstractOBDData
{
    #region Properties & Fields

    public DegreeCelsius Temperature => new(A - 40, -40, 210);

    #endregion

    #region Constructors

    public EngineOilTemperature()
        : base(0x5C, 1)
    { }

    #endregion

    #region Methods

    public override string ToString() => Temperature.ToString();

    #endregion
}