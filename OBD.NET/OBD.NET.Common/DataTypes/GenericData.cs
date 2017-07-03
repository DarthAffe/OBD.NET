using System;

namespace OBD.NET.DataTypes
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

        public GenericData(double value, double minValue, double maxValue)
        {
            this.Value = value;
            this.MinValue = minValue;
            this.MaxValue = maxValue;
            this.IsFloatingPointValue = true;
        }

        public GenericData(int value, int minValue, int maxValue)
        {
            this.Value = value;
            this.MinValue = minValue;
            this.MaxValue = maxValue;
            this.IsFloatingPointValue = false;
        }

        #endregion

        #region Operators

        public static implicit operator double(GenericData p)
        {
            return p.Value;
        }

        public static implicit operator int(GenericData p)
        {
            return (int)Math.Round(p.Value);
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return (IsFloatingPointValue ? Value.ToString("0.00") : Value.ToString()) + (Unit == null ? string.Empty : (" " + Unit));
        }

        #endregion
    }
}
