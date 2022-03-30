﻿using OBD.NET.DataTypes;

namespace OBD.NET.OBDData._00_1F;

public class OxygenSensor8FuelTrim : AbstractOBDData
{
    #region Properties & Fields

    public Volt Voltage => new Volt(A / 200.0, 0, 1.275);
    public Percent ShortTermFuelTrim => new Percent((B / 1.28) - 100, -100, 99.2);
    public bool IsSensorUsed => B != 0xFF;

    #endregion

    #region Constructors

    public OxygenSensor8FuelTrim()
        : base(0x1B, 2)
    { }

    #endregion

    #region Methods

    public override string ToString() => ShortTermFuelTrim.ToString();

    #endregion
}