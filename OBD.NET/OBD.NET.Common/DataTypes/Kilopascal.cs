namespace OBD.NET.Common.DataTypes
{
    public class Kilopascal : GenericData
    {
        #region Properties & Fields

        protected override string Unit => "kPa";

        #endregion

        #region Constructors

        public Kilopascal(double value, double minValue, double maxValue)
            : base(value, minValue, maxValue)
        { }

        public Kilopascal(int value, int minValue, int maxValue)
            : base(value, minValue, maxValue)
        { }

        #endregion

        #region Operators

        public static explicit operator Pascal(Kilopascal pa) => new Pascal(pa.Value / 1000.0, pa.MinValue / 1000.0, pa.MaxValue / 1000.0);

        #endregion
    }
}
