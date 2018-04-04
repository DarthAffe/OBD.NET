namespace OBD.NET.Common.OBDData
{
    public class PidsSupported21_40 : AbstractPidsSupported
    {
        #region Constructors

        public PidsSupported21_40()
            : base(0x20, 4)
        { }

        #endregion

        #region Methods

        public override string ToString() => string.Join(",", SupportedPids);

        #endregion
    }
}
