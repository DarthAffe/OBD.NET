namespace OBD.NET.OBDData._80_9F;

public class PidsSupported81_A0 : AbstractPidsSupported
{
    #region Constructors

    public PidsSupported81_A0()
        : base(0x80, 4)
    { }

    #endregion

    #region Methods

    public override string ToString() => string.Join(",", SupportedPids);

    #endregion
}