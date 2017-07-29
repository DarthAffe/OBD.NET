namespace OBD.NET.Common.OBDData
{
    public class OBDStandards : AbstractOBDData
    {
        #region Properties & Fields

        public OBDStandard Standard => (OBDStandard)A;

        #endregion

        #region Constructors

        public OBDStandards()
            : base(0x1C, 1)
        { }

        #endregion

        #region Enum

        public enum OBDStandard
        {
            Missing = 0,
            OBDII = 1,
            OBD = 2,
            OBD_OBDII = 3,
            OBDI = 4,
            NotOBDCompliant = 5,
            EOBD = 6,
            EOBD_OBDII = 7,
            EOBD_OBD = 8,
            EOBD_OBD_OBDII = 9,
            JOBD = 10,
            JOBD_OBDII = 11,
            JOBD_EOBD = 12,
            JOBD_EOBD_OBDII = 13,
            EMD = 17,
            EMDPlus = 18,
            HDOBDC = 19,
            HDOBD = 20,
            WWHOBD = 21,
            HDEOBDI = 23,
            HDEOBDIN = 24,
            HDEOBDII = 25,
            HDEOBDIIN = 26,
            OBDBr1 = 28,
            OBDBr2 = 29,
            KOBD = 30,
            IOBDI = 31,
            IOBDII = 32,
            HDEOBDIV = 33
        }

        #endregion

        #region Methods

        public override string ToString() => Standard.ToString();

        #endregion
    }
}
