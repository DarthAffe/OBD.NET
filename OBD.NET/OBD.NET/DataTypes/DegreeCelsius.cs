namespace OBD.NET.DataTypes
{
    public class DegreeCelsius : GenericData
    {
        #region Constructors

        public DegreeCelsius(double value, double minValue, double maxValue)
            : base(value, minValue, maxValue)
        { }

        public DegreeCelsius(int value, int minValue, int maxValue)
            : base(value, minValue, maxValue)
        { }

        #endregion
    }
}
