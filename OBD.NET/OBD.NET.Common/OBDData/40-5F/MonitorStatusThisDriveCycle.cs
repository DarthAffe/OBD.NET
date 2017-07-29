namespace OBD.NET.Common.OBDData
{
    public class MonitorStatusThisDriveCycle : AbstractOBDData
    {
        #region Properties & Fields

        public bool IsComponentsTestAvailable => (B & (1 << 3)) != 0;
        public bool IsComponentsTestComplete => (B & (1 << 7)) == 0;

        public bool IsFuelSystemTestAvailable => (B & (1 << 1)) != 0;
        public bool IsFuelSystemTestComplete => (B & (1 << 5)) == 0;

        public bool IsMisfireTestAvailable => (B & (1 << 0)) != 0;
        public bool IsMisfireTestComplete => (B & (1 << 4)) == 0;

        public bool IsEGRSystemTestAvailable => (C & (1 << 7)) != 0;
        public bool IsEGRSystemTestComplete => (D & (1 << 7)) == 0;

        public bool IsOxygenSensorHeaterTestAvailable => (C & (1 << 6)) != 0;
        public bool IsOxygenSensorHeaterTestComplete => (D & (1 << 6)) == 0;

        public bool IsOxygenSensorTestAvailable => (C & (1 << 5)) != 0;
        public bool IsOxygenSensorTestComplete => (D & (1 << 5)) == 0;

        public bool IsACRefrigerantTestAvailable => (C & (1 << 4)) != 0;
        public bool IsACRefrigerantTestComplete => (D & (1 << 4)) == 0;

        public bool IsSecondaryAirSystemTestAvailable => (C & (1 << 3)) != 0;
        public bool IsSecondaryAirSystemTestComplete => (D & (1 << 3)) == 0;

        public bool IsEvaporativeSystemTestAvailable => (C & (1 << 2)) != 0;
        public bool IsEvaporativeSystemTestComplete => (D & (1 << 2)) == 0;

        public bool IsHeatedCatalystTestAvailable => (C & (1 << 1)) != 0;
        public bool IsHeatedCatalystTestComplete => (D & (1 << 1)) == 0;

        public bool IsCatalystAvailable => (C & (1 << 0)) != 0;
        public bool IsCatalystComplete => (D & (1 << 0)) == 0;

        #endregion

        #region Constructors

        public MonitorStatusThisDriveCycle()
            : base(0x41, 4)
        { }

        #endregion

        #region Methods

        public override string ToString() => string.Empty;

        #endregion
    }
}
