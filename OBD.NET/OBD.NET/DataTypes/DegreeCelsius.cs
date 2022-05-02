namespace OBD.NET.DataTypes;

public class DegreeCelsius : GenericData
{
    #region Properties & Fields

    protected override string Unit => "°C";

    #endregion

    #region Constructors

    public DegreeCelsius(double value, double minValue, double maxValue)
        : base(value, minValue, maxValue)
    { }

    public DegreeCelsius(int value, int minValue, int maxValue)
        : base(value, minValue, maxValue)
    { }

    #endregion

    #region Methods

    public override string ToString() => (IsFloatingPointValue ? Value.ToString("0.00") : Value.ToString()) + Unit;

    #endregion
}