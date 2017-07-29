namespace OBD.NET.Common.DataTypes
{
    public class Minute : GenericData
    {
        #region Properties & Fields

        protected override string Unit => "min";

        #endregion

        #region Constructors

        public Minute(double value, double minValue, double maxValue)
            : base(value, minValue, maxValue)
        { }

        public Minute(int value, int minValue, int maxValue)
            : base(value, minValue, maxValue)
        { }

        #endregion

        #region Operators

        public static explicit operator Second(Minute m) => m.IsFloatingPointValue
                                                                ? new Second(m.Value * 60, m.MinValue * 60, m.MaxValue * 60)
                                                                : new Second((int)(m.Value * 60), (int)(m.MinValue * 60), (int)(m.MaxValue * 60));

        #endregion
    }
}
