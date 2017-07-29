using System;

namespace OBD.NET.Common.DataTypes
{
    public abstract class GenericData
    {
        #region Properties & Fields

        public double Value { get; }
        public double MinValue { get; }
        public double MaxValue { get; }
        public bool IsFloatingPointValue { get; }

        protected abstract string Unit { get; }

        #endregion

        #region Constructors

        protected GenericData(double value, double minValue, double maxValue)
        {
            this.Value = value;
            this.MinValue = minValue;
            this.MaxValue = maxValue;
            this.IsFloatingPointValue = true;
        }

        protected GenericData(int value, int minValue, int maxValue)
        {
            this.Value = value;
            this.MinValue = minValue;
            this.MaxValue = maxValue;
            this.IsFloatingPointValue = false;
        }

        #endregion

        #region Operators

        public static implicit operator double(GenericData p) => p.Value;

        public static implicit operator int(GenericData p) => (int)Math.Round(p.Value);

        #endregion

        #region Methods

        public override string ToString() => (IsFloatingPointValue ? Value.ToString("0.00") : Value.ToString()) + (Unit == null ? string.Empty : (" " + Unit));

        #endregion
    }
}
