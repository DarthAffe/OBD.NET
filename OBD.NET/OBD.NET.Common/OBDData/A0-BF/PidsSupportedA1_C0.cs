namespace OBD.NET.Common.OBDData
{
    public class PidsSupportedA1_C0 : AbstractPidsSupported
    {
        #region Constructors

        public PidsSupportedA1_C0()
            : base(0xA0, 4)
        { }

        #endregion

        #region Methods

        public override string ToString() => string.Join(",", SupportedPids);

        #endregion
    }
}
