using OBD.NET.DataTypes;

namespace OBD.NET.OBDData._40_5F;

public class LongtTermSecondaryOxygenSensorTrimBank13 : AbstractOBDData
{
    #region Properties & Fields

    public Percent Bank1 => new Percent((A / 1.28) - 100, -100, 99.2);
    public Percent Bank3 => new Percent((B / 1.28) - 100, -100, 99.2);

    #endregion

    #region Constructors

    public LongtTermSecondaryOxygenSensorTrimBank13()
        : base(0x56, 2)
    { }

    #endregion

    #region Methods

    public override string ToString() => Bank1.ToString();

    #endregion
}