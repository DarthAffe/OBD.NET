﻿using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class IntakeAirTemperature : AbstractOBDData
{
    #region Properties & Fields

    public DegreeCelsius Temperature => new(A - 40, -40, 215);

    #endregion

    #region Constructors

    public IntakeAirTemperature()
        : base(0x0F, 1)
    { }

    #endregion

    #region Methods

    public override string ToString() => Temperature.ToString();

    #endregion
}