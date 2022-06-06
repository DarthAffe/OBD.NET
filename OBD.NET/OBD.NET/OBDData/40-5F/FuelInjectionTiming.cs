﻿using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class FuelInjectionTiming : AbstractOBDData
{
    #region Properties & Fields

    public Degree Timing => new((((256 * A) + B) / 128.0) - 210, -210, 301.992);

    #endregion

    #region Constructors

    public FuelInjectionTiming()
        : base(0x5D, 2)
    { }

    #endregion

    #region Methods

    public override string ToString() => Timing.ToString();

    #endregion
}