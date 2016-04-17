namespace OBD.NET.OBDData
{
    public class LongTermSecondaryOxygenSensorTrimBank24 : AbstractOBDData
    {
        #region Properties & Fields

        public double Bank2 => (A / 1.28) - 100;
        public double Bank4 => (B / 1.28) - 100;

        #endregion

        #region Constructors

        public LongTermSecondaryOxygenSensorTrimBank24()
            : base(0x58, 2)
        { }

        #endregion
    }
}
