namespace OBD.NET.Common.DataTypes
{
    public class Milliampere : GenericData
    {
        #region Properties & Fields

        protected override string Unit => "mA";

        #endregion

        #region Constructors

        public Milliampere(double value, double minValue, double maxValue)
            : base(value, minValue, maxValue)
        { }

        public Milliampere(int value, int minValue, int maxValue)
            : base(value, minValue, maxValue)
        { }

        #endregion
    }
}
