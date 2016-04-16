namespace OBD.NET.OBDData
{
    public class IntakeManifoldAbsolutePressure : AbstractOBDData
    {
        #region Properties & Fields

        public int Pressure => A;

        #endregion

        #region Constructors

        public IntakeManifoldAbsolutePressure()
            : base(0x0B, 1)
        { }

        #endregion
    }
}
