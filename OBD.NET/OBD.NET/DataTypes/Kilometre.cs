namespace OBD.NET.DataTypes
{
    public class Kilometre : GenericData
    {
        #region Constructors

        public Kilometre(double value, double minValue, double maxValue)
            : base(value, minValue, maxValue)
        { }

        public Kilometre(int value, int minValue, int maxValue)
            : base(value, minValue, maxValue)
        { }

        #endregion
    }
}
