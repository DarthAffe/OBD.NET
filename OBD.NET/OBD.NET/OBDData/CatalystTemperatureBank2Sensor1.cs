namespace OBD.NET.OBDData
{
    public class CatalystTemperatureBank2Sensor1 : AbstractOBDData
    {
        #region Properties & Fields

        public double Temperature => (((256 * A) + B) / 10.0) - 40;

        #endregion

        #region Constructors

        public CatalystTemperatureBank2Sensor1()
            : base(0x3E, 2)
        { }

        #endregion
    }
}
