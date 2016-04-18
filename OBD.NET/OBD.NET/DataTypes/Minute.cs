namespace OBD.NET.DataTypes
{
    public class Minute : GenericData
    {
        #region Constructors

        public Minute(double value, double minValue, double maxValue)
            : base(value, minValue, maxValue)
        { }

        public Minute(int value, int minValue, int maxValue)
            : base(value, minValue, maxValue)
        { }

        #endregion

        #region Operators

        public static explicit operator Second(Minute m)
        {
            return m.IsFloatingPointValue
                ? new Second(m.Value * 60, m.MinValue * 60, m.MaxValue * 60)
                : new Second((int)(m.Value * 60), (int)(m.MinValue * 60), (int)(m.MaxValue * 60));
        }

        #endregion
    }
}
