namespace OBD.NET.Common.DataTypes
{
    public class Degree : GenericData
    {
        #region Properties & Fields

        protected override string Unit => "°";

        #endregion

        #region Constructors

        public Degree(double value, double minValue, double maxValue)
            : base(value, minValue, maxValue)
        { }

        public Degree(int value, int minValue, int maxValue)
            : base(value, minValue, maxValue)
        { }

        #endregion
    }
}
