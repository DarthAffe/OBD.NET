﻿using OBD.NET.DataTypes;

namespace OBD.NET.OBDData._40_5F;

public class EthanolFuel : AbstractOBDData
{
    #region Properties & Fields

    public Percent Value => new Percent(A / 2.55, 0, 100);

    #endregion

    #region Constructors

    public EthanolFuel()
        : base(0x52, 1)
    { }

    #endregion

    #region Methods

    public override string ToString() => Value.ToString();

    #endregion
}