namespace OBD.NET.Common.DataTypes
{
    public class Percent : GenericData
    {
        #region Properties & Fields

        protected override string Unit => "%";

        #endregion

        #region Constructors

        public Percent(double value, double minValue, double maxValue)
            : base(value, minValue, maxValue)
        { }

        public Percent(int value, int minValue, int maxValue)
            : base(value, minValue, maxValue)
        { }

        #endregion
    }
}
