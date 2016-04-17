namespace OBD.NET.OBDData
{
    public class AmbientAirTemperature : AbstractOBDData
    {
        #region Properties & Fields

        public int Temperature => A - 40;

        #endregion

        #region Constructors

        public AmbientAirTemperature()
            : base(0x46, 1)
        { }

        #endregion
    }
}
