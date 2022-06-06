﻿using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class TimeRunWithMILOn : AbstractOBDData
{
    #region Properties & Fields

    public Minute Time => new((256 * A) + B, 0, 65535);

    #endregion

    #region Constructors

    public TimeRunWithMILOn()
        : base(0x4D, 2)
    { }

    #endregion

    #region Methods

    public override string ToString() => Time.ToString();

    #endregion
}