namespace OBD.NET.Common.OBDData
{
    public class PidsSupported41_60 : AbstractPidsSupported
    {
        #region Constructors

        public PidsSupported41_60()
            : base(0x40, 4)
        { }

        #endregion

        #region Methods

        public override string ToString() => string.Join(",", SupportedPids);

        #endregion
    }
}
