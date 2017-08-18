namespace OBD.NET.Common.DataTypes
{
    public class Kilometre : GenericData
    {
        #region Properties & Fields

        protected override string Unit => "km";

        #endregion

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
