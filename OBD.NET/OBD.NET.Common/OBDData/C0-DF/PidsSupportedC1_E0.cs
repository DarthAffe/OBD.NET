namespace OBD.NET.Common.OBDData
{
    public class PidsSupportedC1_E0 : AbstractPidsSupported
    {
        #region Constructors

        public PidsSupportedC1_E0()
            : base(0xC0, 4)
        { }

        #endregion

        #region Methods

        public override string ToString() => string.Join(",", SupportedPids);

        #endregion
    }
}
