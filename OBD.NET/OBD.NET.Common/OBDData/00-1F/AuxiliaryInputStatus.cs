namespace OBD.NET.Common.OBDData
{
    public class AuxiliaryInputStatus : AbstractOBDData
    {
        #region Properties & Fields

        public bool PowerTakeOffStatus => (A & (1 << 0)) != 0;

        #endregion

        #region Constructors

        public AuxiliaryInputStatus()
            : base(0x1E, 1)
        { }

        #endregion

        #region Methods

        public override string ToString() => PowerTakeOffStatus.ToString();

        #endregion
    }
}
