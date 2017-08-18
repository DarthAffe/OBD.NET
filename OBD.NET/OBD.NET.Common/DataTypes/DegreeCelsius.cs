namespace OBD.NET.Common.DataTypes
{
    public class DegreeCelsius : GenericData
    {
        #region Properties & Fields

        protected override string Unit => "°C";

        #endregion

        #region Constructors

        public DegreeCelsius(double value, double minValue, double maxValue)
            : base(value, minValue, maxValue)
        { }

        public DegreeCelsius(int value, int minValue, int maxValue)
            : base(value, minValue, maxValue)
        { }

        #endregion
    }
}
