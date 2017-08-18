namespace OBD.NET.Common.DataTypes
{
    public class Count : GenericData
    {
        #region Properties & Fields

        protected override string Unit => null;

        #endregion

        #region Constructors

        public Count(double value, double minValue, double maxValue)
            : base(value, minValue, maxValue)
        { }

        public Count(int value, int minValue, int maxValue)
            : base(value, minValue, maxValue)
        { }

        #endregion
    }
}
