namespace OBD.NET.OBDData
{
    public class EthanolFuel : AbstractOBDData
    {
        #region Properties & Fields

        public double Value => A / 2.55;

        #endregion

        #region Constructors

        public EthanolFuel()
            : base(0x52, 1)
        { }

        #endregion
    }
}
