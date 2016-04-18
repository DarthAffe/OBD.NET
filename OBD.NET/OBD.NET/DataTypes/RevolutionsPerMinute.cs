namespace OBD.NET.DataTypes
{
    public class RevolutionsPerMinute : GenericData
    {
        #region Constructors

        public RevolutionsPerMinute(double value, double minValue, double maxValue)
            : base(value, minValue, maxValue)
        { }

        public RevolutionsPerMinute(int value, int minValue, int maxValue)
            : base(value, minValue, maxValue)
        { }

        #endregion
    }
}
