namespace OBD.NET.Common.DataTypes
{
    public class LitresPerHour : GenericData
    {
        #region Properties & Fields

        protected override string Unit => "l/h";

        #endregion

        #region Constructors

        public LitresPerHour(double value, double minValue, double maxValue)
            : base(value, minValue, maxValue)
        { }

        public LitresPerHour(int value, int minValue, int maxValue)
            : base(value, minValue, maxValue)
        { }

        #endregion
    }
}
