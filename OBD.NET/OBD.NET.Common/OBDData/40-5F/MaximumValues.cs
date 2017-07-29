using OBD.NET.Common.DataTypes;

namespace OBD.NET.Common.OBDData
{
    public class MaximumValues : AbstractOBDData
    {
        #region Properties & Fields

        public Ratio FuelAirEquivalenceRatio => new Ratio(A, 0, 255);
        public Volt OxygenSensorVoltage => new Volt(B, 0, 255);
        public Milliampere OxygenSensorCurrent => new Milliampere(C, 0, 255);
        public Kilopascal IntakeManifoldAbsolutePressure => new Kilopascal(D * 10, 0, 2550);

        #endregion

        #region Constructors

        public MaximumValues()
            : base(0x4F, 4)
        { }

        #endregion

        #region Methods

        public override string ToString() => FuelAirEquivalenceRatio.ToString();

        #endregion
    }
}
