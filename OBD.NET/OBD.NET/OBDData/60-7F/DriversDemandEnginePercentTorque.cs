using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class DriversDemandEnginePercentTorque : AbstractOBDData
{
    #region Properties & Fields

    public Percent Torque => new(A - 125, -125, 125);

    #endregion

    #region Constructors

    public DriversDemandEnginePercentTorque()
        : base(0x61, 1)
    { }

    #endregion

    #region Methods

    public override string ToString() => Torque.ToString();

    #endregion
}