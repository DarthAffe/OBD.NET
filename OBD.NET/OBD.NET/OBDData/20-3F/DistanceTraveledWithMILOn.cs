using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class DistanceTraveledWithMILOn : AbstractOBDData
{
    #region Properties & Fields

    public Kilometre Distance => new((256 * A) + B, 0, 65535);

    #endregion

    #region Constructors

    public DistanceTraveledWithMILOn()
        : base(0x21, 2)
    { }

    #endregion

    #region Methods

    public override string ToString() => Distance.ToString();

    #endregion
}