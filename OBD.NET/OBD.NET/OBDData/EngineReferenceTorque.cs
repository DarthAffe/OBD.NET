namespace OBD.NET.OBDData
{
    public class EngineReferenceTorque : AbstractOBDData
    {
        #region Properties & Fields

        public int Torque => (256 * A) + B;

        #endregion

        #region Constructors

        public EngineReferenceTorque()
            : base(0x63, 2)
        { }

        #endregion
    }
}
