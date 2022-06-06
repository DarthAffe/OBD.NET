using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class WarmUpsSinceCodesCleared : AbstractOBDData
{
    #region Properties & Fields

    public Count WarmUps => new(A, 0, 255);

    #endregion

    #region Constructors

    public WarmUpsSinceCodesCleared()
        : base(0x30, 1)
    { }

    #endregion

    #region Methods

    public override string ToString() => WarmUps.ToString();

    #endregion
}