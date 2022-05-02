using OBD.NET.DataTypes;

namespace OBD.NET.OBDData._00_1F;

public class CalculatedEngineLoad : AbstractOBDData
{
    #region Properties & Fields

    public Percent Load => new(A / 2.55, 0, 100);

    #endregion

    #region Constructors

    public CalculatedEngineLoad()
        : base(0x04, 1)
    { }

    #endregion

    #region Methods

    public override string ToString() => Load.ToString();

    #endregion
}