namespace OBD.NET.Common.OBDData
{
    public class PidsSupported01_20 : AbstractPidsSupported
    {
        #region Constructors

        public PidsSupported01_20()
            : base(0x00, 4)
        { }

        #endregion

        #region Methods

        public override string ToString() => string.Join(",", SupportedPids);

        #endregion
    }
}
