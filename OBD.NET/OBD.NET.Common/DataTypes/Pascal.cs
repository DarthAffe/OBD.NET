namespace OBD.NET.Common.DataTypes
{
    public class Pascal : GenericData
    {
        #region Properties & Fields

        protected override string Unit => "Pa";

        #endregion

        #region Constructors

        public Pascal(double value, double minValue, double maxValue)
            : base(value, minValue, maxValue)
        { }

        public Pascal(int value, int minValue, int maxValue)
            : base(value, minValue, maxValue)
        { }

        #endregion

        #region Operators

        public static explicit operator Kilopascal(Pascal pa) => pa.IsFloatingPointValue
                                                                     ? new Kilopascal(pa.Value * 1000, pa.MinValue * 1000, pa.MaxValue * 1000)
                                                                     : new Kilopascal((int)(pa.Value * 1000), (int)(pa.MinValue * 1000), (int)(pa.MaxValue * 1000));

        #endregion
    }
}
