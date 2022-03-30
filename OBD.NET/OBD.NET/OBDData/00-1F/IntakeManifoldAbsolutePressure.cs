﻿using OBD.NET.DataTypes;

namespace OBD.NET.OBDData._00_1F;

public class IntakeManifoldAbsolutePressure : AbstractOBDData
{
    #region Properties & Fields

    public Kilopascal Pressure => new Kilopascal(A, 0, 255);

    #endregion

    #region Constructors

    public IntakeManifoldAbsolutePressure()
        : base(0x0B, 1)
    { }

    #endregion

    #region Methods

    public override string ToString() => Pressure.ToString();

    #endregion
}