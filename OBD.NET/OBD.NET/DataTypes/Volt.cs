namespace OBD.NET.DataTypes
{
    public class Volt : GenericData
    {
        #region Constructors

        public Volt(double value, double minValue, double maxValue)
            : base(value, minValue, maxValue)
        { }

        public Volt(int value, int minValue, int maxValue)
            : base(value, minValue, maxValue)
        { }

        #endregion
    }
}
