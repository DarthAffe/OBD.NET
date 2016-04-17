namespace OBD.NET.OBDData
{
    public class ShortTermSecondaryOxygenSensorTrimBank13 : AbstractOBDData
    {
        #region Properties & Fields

        public double Bank1 => (A / 1.28) - 100;
        public double Bank3 => (B / 1.28) - 100;

        #endregion

        #region Constructors

        public ShortTermSecondaryOxygenSensorTrimBank13()
            : base(0x55, 2)
        { }

        #endregion
    }
}
