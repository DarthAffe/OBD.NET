using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class EvapSystemVaporPressure : AbstractOBDData
{
    #region Properties & Fields

    public Pascal Pressure => new(((256 * A) + B) / 4.0, -8192, 8191.75);

    #endregion

    #region Constructors

    public EvapSystemVaporPressure()
        : base(0x32, 2)
    { }

    #endregion

    #region Methods

    public override string ToString() => Pressure.ToString();

    #endregion
}