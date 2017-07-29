namespace OBD.NET.Common.DataTypes
{
    public class NewtonMetre : GenericData
    {
        #region Properties & Fields

        protected override string Unit => "N";

        #endregion

        #region Constructors

        public NewtonMetre(double value, double minValue, double maxValue)
            : base(value, minValue, maxValue)
        { }

        public NewtonMetre(int value, int minValue, int maxValue)
            : base(value, minValue, maxValue)
        { }

        #endregion
    }
}
