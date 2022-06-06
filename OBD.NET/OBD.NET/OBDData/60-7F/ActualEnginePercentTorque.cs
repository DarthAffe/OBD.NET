﻿using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class ActualEnginePercentTorque : AbstractOBDData
{
    #region Properties & Fields

    public Percent Torque => new(A - 125, -125, 125);

    #endregion

    #region Constructors

    public ActualEnginePercentTorque()
        : base(0x62, 1)
    { }

    #endregion

    #region Methods

    public override string ToString() => Torque.ToString();

    #endregion
}