using OBD.NET.Common.DataTypes;

namespace OBD.NET.Common.OBDData
{
    public class EngineReferenceTorque : AbstractOBDData
    {
        #region Properties & Fields

        public NewtonMetre Torque => new NewtonMetre((256 * A) + B, 0, 65535);

        #endregion

        #region Constructors

        public EngineReferenceTorque()
            : base(0x63, 2)
        { }

        #endregion

        #region Methods

        public override string ToString() => Torque.ToString();

        #endregion
    }
}
