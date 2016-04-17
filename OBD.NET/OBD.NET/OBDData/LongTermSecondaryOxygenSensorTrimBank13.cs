namespace OBD.NET.OBDData
{
    public class LongtTermSecondaryOxygenSensorTrimBank13 : AbstractOBDData
    {
        #region Properties & Fields

        public double Bank1 => (A / 1.28) - 100;
        public double Bank3 => (B / 1.28) - 100;

        #endregion

        #region Constructors

        public LongtTermSecondaryOxygenSensorTrimBank13()
            : base(0x56, 2)
        { }

        #endregion
    }
}
