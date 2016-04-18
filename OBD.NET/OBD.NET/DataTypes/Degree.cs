namespace OBD.NET.DataTypes
{
    public class Degree : GenericData
    {
        #region Constructors

        public Degree(double value, double minValue, double maxValue)
            : base(value, minValue, maxValue)
        { }

        public Degree(int value, int minValue, int maxValue)
            : base(value, minValue, maxValue)
        { }

        #endregion
    }
}
