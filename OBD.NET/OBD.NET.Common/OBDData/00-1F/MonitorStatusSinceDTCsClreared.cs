namespace OBD.NET.Common.OBDData
{
    public class MonitorStatusSinceDTCsClreared : AbstractOBDData
    {
        #region Properties & Fields

        public bool IsMilOn => (A & (1 << 7)) != 0;

        public int DTCCount => A & ~(1 << 7);

        //TODO DarthAffe 26.08.2017: Implement Test-Bits https://en.wikipedia.org/wiki/OBD-II_PIDs#Mode_1_PID_01

        #endregion

        #region Constructors

        public MonitorStatusSinceDTCsClreared()
            : base(0x01, 4)
        { }

        #endregion

        #region Methods

        public override string ToString() => IsMilOn.ToString();

        #endregion
    }
}
