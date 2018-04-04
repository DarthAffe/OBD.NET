namespace OBD.NET.Common.OBDData
{
    public class PidsSupported61_80 : AbstractPidsSupported
    {
        #region Constructors

        public PidsSupported61_80()
            : base(0x60, 4)
        { }

        #endregion

        #region Methods

        public override string ToString() => string.Join(",", SupportedPids);

        #endregion
    }
}
