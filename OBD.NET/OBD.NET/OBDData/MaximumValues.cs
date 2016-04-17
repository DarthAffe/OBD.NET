namespace OBD.NET.OBDData
{
    public class MaximumValues : AbstractOBDData
    {
        #region Properties & Fields

        public int FuelAirEquivalenceRatio => A;
        public int OxygenSensorVoltage => B;
        public int OxygenSensorCurrent => C;
        public int IntakeManifoldAbsolutePressure => D * 10;

        #endregion

        #region Constructors

        public MaximumValues()
            : base(0x4F, 4)
        { }

        #endregion
    }
}
