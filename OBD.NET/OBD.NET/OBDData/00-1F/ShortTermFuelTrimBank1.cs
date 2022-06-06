using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class ShortTermFuelTrimBank1 : AbstractOBDData
{
    #region Properties & Fields

    public Percent Trim => new((A / 1.28) - 100, -100, 99.2);

    #endregion

    #region Constructors

    public ShortTermFuelTrimBank1()
        : base(0x06, 1)
    { }

    #endregion

    #region Methods

    public override string ToString() => Trim.ToString();

    #endregion
}