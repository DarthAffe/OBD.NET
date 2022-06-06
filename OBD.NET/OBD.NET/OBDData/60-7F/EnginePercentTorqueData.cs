using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class EnginePercentTorqueData : AbstractOBDData
{
    #region Properties & Fields

    public Percent Idle => new(A - 125, -125, 125);
    public Percent EnginePoint1 => new(B - 125, -125, 125);
    public Percent EnginePoint2 => new(C - 125, -125, 125);
    public Percent EnginePoint3 => new(D - 125, -125, 125);
    public Percent EnginePoint4 => new(E - 125, -125, 125);

    #endregion

    #region Constructors

    public EnginePercentTorqueData()
        : base(0x64, 5)
    { }

    #endregion

    #region Methods

    public override string ToString() => Idle.ToString();

    #endregion
}