namespace OBD.NET.Common.DataTypes
{
    public class RevolutionsPerMinute : GenericData
    {
        #region Properties & Fields

        protected override string Unit => "rpm";

        #endregion

        #region Constructors

        public RevolutionsPerMinute(double value, double minValue, double maxValue)
            : base(value, minValue, maxValue)
        { }

        public RevolutionsPerMinute(int value, int minValue, int maxValue)
            : base(value, minValue, maxValue)
        { }

        #endregion
    }
}
