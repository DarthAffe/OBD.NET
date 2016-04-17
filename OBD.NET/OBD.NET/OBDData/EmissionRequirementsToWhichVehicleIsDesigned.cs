namespace OBD.NET.OBDData
{
    public class EmissionRequirementsToWhichVehicleIsDesigned : AbstractOBDData
    {
        #region Properties & Fields

        public byte EmissionRequirement => A;

        #endregion

        #region Constructors

        public EmissionRequirementsToWhichVehicleIsDesigned()
            : base(0x5F, 1)
        { }

        #endregion
    }
}
