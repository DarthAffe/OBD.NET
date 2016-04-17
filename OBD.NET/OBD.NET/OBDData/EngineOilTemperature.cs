namespace OBD.NET.OBDData
{
    public class EngineOilTemperature : AbstractOBDData
    {
        #region Properties & Fields

        public int Temperature => A - 40;

        #endregion

        #region Constructors

        public EngineOilTemperature()
            : base(0x5C, 1)
        { }

        #endregion
    }
}
