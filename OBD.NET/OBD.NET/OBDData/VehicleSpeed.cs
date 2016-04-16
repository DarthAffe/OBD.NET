namespace OBD.NET.OBDData
{
    public class VehicleSpeed : AbstractOBDData
    {
        #region Properties & Fields

        public int Speed => A;

        #endregion

        #region Constructors

        public VehicleSpeed()
            : base(0x0D, 1)
        { }

        #endregion
    }
}
