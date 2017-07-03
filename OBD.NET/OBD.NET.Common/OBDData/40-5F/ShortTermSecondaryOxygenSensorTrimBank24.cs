using OBD.NET.DataTypes;

namespace OBD.NET.OBDData
{
    public class ShortTermSecondaryOxygenSensorTrimBank24 : AbstractOBDData
    {
        #region Properties & Fields

        public Percent Bank2 => new Percent((A / 1.28) - 100, -100, 99.2);
        public Percent Bank4 => new Percent((B / 1.28) - 100, -100, 99.2);

        #endregion

        #region Constructors

        public ShortTermSecondaryOxygenSensorTrimBank24()
            : base(0x57, 2)
        { }

        #endregion
    }
}
