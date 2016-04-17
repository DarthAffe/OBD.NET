namespace OBD.NET.OBDData
{
    public class EGRError : AbstractOBDData
    {
        #region Properties & Fields

        public double Error => (A / 1.28) - 100;

        #endregion

        #region Constructors

        public EGRError()
            : base(0x2D, 1)
        { }

        #endregion
    }
}
