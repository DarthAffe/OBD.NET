namespace OBD.NET.OBDData
{
    public class CatalystTemperatureBank1Sensor2 : AbstractOBDData
    {
        #region Properties & Fields

        public double Temperature => (((256 * A) + B) / 10.0) - 40;

        #endregion

        #region Constructors

        public CatalystTemperatureBank1Sensor2()
            : base(0x3D, 2)
        { }

        #endregion
    }
}
