namespace OBD.NET.DataTypes
{
    public class KilometrePerHour : GenericData
    {
        #region Constructors

        public KilometrePerHour(double value, double minValue, double maxValue)
            : base(value, minValue, maxValue)
        { }

        public KilometrePerHour(int value, int minValue, int maxValue)
            : base(value, minValue, maxValue)
        { }

        #endregion
    }
}
