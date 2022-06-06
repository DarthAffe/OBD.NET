﻿using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class TimingAdvance : AbstractOBDData
{
    #region Properties & Fields

    public Degree Timing => new((A / 2.0) - 64, -64, 63.5);

    #endregion

    #region Constructors

    public TimingAdvance()
        : base(0x0E, 1)
    { }

    #endregion

    #region Methods

    public override string ToString() => Timing.ToString();

    #endregion
}