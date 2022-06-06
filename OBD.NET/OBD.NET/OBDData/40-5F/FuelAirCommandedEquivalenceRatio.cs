﻿using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class FuelAirCommandedEquivalenceRatio : AbstractOBDData
{
    #region Properties & Fields

    public Ratio Ratio => new((2.0 / 65536.0) * ((256 * A) + B), 0, 2.0 - double.Epsilon);

    #endregion

    #region Constructors

    public FuelAirCommandedEquivalenceRatio()
        : base(0x44, 2)
    { }

    #endregion

    #region Methods

    public override string ToString() => Ratio.ToString();

    #endregion
}