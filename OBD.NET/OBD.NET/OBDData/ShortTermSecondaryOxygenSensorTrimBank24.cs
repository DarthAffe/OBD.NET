namespace OBD.NET.OBDData
{
    public class ShortTermSecondaryOxygenSensorTrimBank24 : AbstractOBDData
    {
        #region Properties & Fields

        public double Bank2 => (A / 1.28) - 100;
        public double Bank4 => (B / 1.28) - 100;

        #endregion

        #region Constructors

        public ShortTermSecondaryOxygenSensorTrimBank24()
            : base(0x57, 2)
        { }

        #endregion
    }
}
