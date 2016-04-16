namespace OBD.NET.OBDData
{
    public class IntakeAirTemperature : AbstractOBDData
    {
        #region Properties & Fields

        public int Temperature => A - 40;

        #endregion

        #region Constructors

        public IntakeAirTemperature()
            : base(0x0F, 1)
        { }

        #endregion
    }
}
