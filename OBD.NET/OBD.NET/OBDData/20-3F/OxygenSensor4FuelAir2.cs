﻿using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class OxygenSensor4FuelAir2 : AbstractOBDData
{
    #region Properties & Fields

    public Ratio FuelAirEquivalenceRatio => new((2.0 / 25536.0) * ((256 * A) + B), 0, 2 - double.Epsilon);
    public Milliampere Current => new((C + (D / 256.0)) - 128, -128, 128 - double.Epsilon);

    #endregion

    #region Constructors

    public OxygenSensor4FuelAir2()
        : base(0x37, 4)
    { }

    #endregion

    #region Methods

    public override string ToString() => FuelAirEquivalenceRatio.ToString();

    #endregion
}