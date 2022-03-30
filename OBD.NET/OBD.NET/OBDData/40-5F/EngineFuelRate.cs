﻿using OBD.NET.DataTypes;

namespace OBD.NET.OBDData._40_5F;

public class EngineFuelRate : AbstractOBDData
{
    #region Properties & Fields

    public LitresPerHour FuelRate => new LitresPerHour(((256 * A) + B) / 20.0, 0, 3212.75);

    #endregion

    #region Constructors

    public EngineFuelRate()
        : base(0x5E, 2)
    { }

    #endregion

    #region Methods

    public override string ToString() => FuelRate.ToString();

    #endregion
}