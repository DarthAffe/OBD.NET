namespace OBD.NET.OBDData
{
    public class DistanceTraveledWithMILOn : AbstractOBDData
    {
        #region Properties & Fields

        public int Distance => (256 * A) + B;

        #endregion

        #region Constructors

        public DistanceTraveledWithMILOn()
            : base(0x21, 2)
        { }

        #endregion
    }
}
