using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class MaximumValueForAirFlowRate : AbstractOBDData
{
    #region Properties & Fields

    public GramPerSec Value => new(A * 10, 0, 2550);

    #endregion

    #region Constructors

    public MaximumValueForAirFlowRate()
        : base(0x50, 4)
    { }

    #endregion

    #region Methods

    public override string ToString() => Value.ToString();

    #endregion
}