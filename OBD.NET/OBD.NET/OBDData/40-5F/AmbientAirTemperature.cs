using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class AmbientAirTemperature : AbstractOBDData
{
    #region Properties & Fields

    public DegreeCelsius Temperature => new(A - 40, -40, 215);

    #endregion

    #region Constructors

    public AmbientAirTemperature()
        : base(0x46, 1)
    { }

    #endregion

    #region Methods

    public override string ToString() => Temperature.ToString();

    #endregion
}