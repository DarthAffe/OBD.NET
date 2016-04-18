namespace OBD.NET.DataTypes
{
    public class NewtonMetre : GenericData
    {
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
