using OBD.NET.DataTypes;

namespace OBD.NET.OBDData._20_3F;

public class EGRError : AbstractOBDData
{
    #region Properties & Fields

    public Percent Error => new Percent((A / 1.28) - 100, -100, 99.2);

    #endregion

    #region Constructors

    public EGRError()
        : base(0x2D, 1)
    { }

    #endregion

    #region Methods

    public override string ToString() => Error.ToString();

    #endregion
}