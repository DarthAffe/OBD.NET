namespace OBD.NET.Common.DataTypes
{
    public class Second : GenericData
    {
        #region Properties & Fields

        protected override string Unit => "s";

        #endregion

        #region Constructors

        public Second(double value, double minValue, double maxValue)
            : base(value, minValue, maxValue)
        { }

        public Second(int value, int minValue, int maxValue)
            : base(value, minValue, maxValue)
        { }

        #endregion

        #region Operators

        public static explicit operator Minute(Second s) => new Minute(s.Value / 60.0, s.MinValue / 60.0, s.MaxValue / 60.0);

        #endregion
    }
}
