namespace OBD.NET.DataTypes
{
    public class LitresPerHour : GenericData
    {
        #region Constructors

        public LitresPerHour(double value, double minValue, double maxValue)
            : base(value, minValue, maxValue)
        { }

        public LitresPerHour(int value, int minValue, int maxValue)
            : base(value, minValue, maxValue)
        { }

        #endregion
    }
}
