﻿using OBD.NET.DataTypes;

namespace OBD.NET.OBDData._00_1F;

public class VehicleSpeed : AbstractOBDData
{
    #region Properties & Fields

    public KilometrePerHour Speed => new KilometrePerHour(A, 0, 255);

    #endregion

    #region Constructors

    public VehicleSpeed()
        : base(0x0D, 1)
    { }

    #endregion

    #region Methods

    public override string ToString() => Speed.ToString();

    #endregion
}