using OBD.NET.DataTypes;

namespace OBD.NET.OBDData._40_5F;

public class AbsoluteEvapSystemVaporPressure : AbstractOBDData
{
    #region Properties & Fields

    public Kilopascal Pressure => new Kilopascal(((256 * A) + B) / 200.0, 0, 327.675);

    #endregion

    #region Constructors

    public AbsoluteEvapSystemVaporPressure()
        : base(0x53, 2)
    { }

    #endregion

    #region Methods

    public override string ToString() => Pressure.ToString();

    #endregion
}