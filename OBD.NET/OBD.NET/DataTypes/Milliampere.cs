namespace OBD.NET.DataTypes
{
    public class Milliampere : GenericData
    {
        #region Constructors

        public Milliampere(double value, double minValue, double maxValue)
            : base(value, minValue, maxValue)
        { }

        public Milliampere(int value, int minValue, int maxValue)
            : base(value, minValue, maxValue)
        { }

        #endregion
    }
}
