namespace OBD.NET.Common.DataTypes
{
    public class KilometrePerHour : GenericData
    {
        #region Properties & Fields

        protected override string Unit => "km/h";

        #endregion

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
