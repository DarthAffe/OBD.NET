using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class MAFAirFlowRate : AbstractOBDData
{
    #region Properties & Fields

    public GramPerSec Rate => new(((256 * A) + B) / 100.0, 0, 655.35);

    #endregion

    #region Constructors

    public MAFAirFlowRate()
        : base(0x10, 2)
    { }

    #endregion

    #region Methods

    public override string ToString() => Rate.ToString();

    #endregion
}