namespace OBD.NET.OBDData
{
    public class EngineCoolantTemperature : AbstractOBDData
    {
        #region Properties & Fields

        public int Temperature => A - 40;

        #endregion

        #region Constructors

        public EngineCoolantTemperature()
            : base(0x05, 1)
        { }

        #endregion
    }
}
