using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class VehicleSpeed : AbstractOBDData
{
    #region Properties & Fields

    public KilometrePerHour Speed => new(A, 0, 255);

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