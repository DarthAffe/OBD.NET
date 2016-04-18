namespace OBD.NET.DataTypes
{
    public class GramPerSec : GenericData
    {
        #region Constructors

        public GramPerSec(double value, double minValue, double maxValue)
            : base(value, minValue, maxValue)
        { }

        public GramPerSec(int value, int minValue, int maxValue)
            : base(value, minValue, maxValue)
        { }

        #endregion
    }
}
