using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class AbsoluteBarometricPressure : AbstractOBDData
{
    #region Properties & Fields

    public Kilopascal Pressure => new(A, 0, 255);

    #endregion

    #region Constructors

    public AbsoluteBarometricPressure()
        : base(0x33, 1)
    { }

    #endregion

    #region Methods

    public override string ToString() => Pressure.ToString();

    #endregion
}