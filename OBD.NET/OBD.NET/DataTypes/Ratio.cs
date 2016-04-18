namespace OBD.NET.DataTypes
{
    public class Ratio : GenericData
    {
        #region Constructors

        public Ratio(double value, double minValue, double maxValue)
            : base(value, minValue, maxValue)
        { }

        public Ratio(int value, int minValue, int maxValue)
            : base(value, minValue, maxValue)
        { }

        #endregion
    }
}
