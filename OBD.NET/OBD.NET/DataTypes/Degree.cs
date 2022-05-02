namespace OBD.NET.DataTypes;

public class Degree : GenericData
{
    #region Properties & Fields

    protected override string Unit => "°";

    #endregion

    #region Constructors

    public Degree(double value, double minValue, double maxValue)
        : base(value, minValue, maxValue)
    { }

    public Degree(int value, int minValue, int maxValue)
        : base(value, minValue, maxValue)
    { }

    #endregion

    #region Methods

    public override string ToString() => (IsFloatingPointValue ? Value.ToString("0.00") : Value.ToString()) + Unit;

    #endregion
}