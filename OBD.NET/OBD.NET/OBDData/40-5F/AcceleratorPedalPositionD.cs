using OBD.NET.DataTypes;

namespace OBD.NET.OBDData
{
    public class AcceleratorPedalPositionD : AbstractOBDData
    {
        #region Properties & Fields

        public Percent Position => new Percent(A / 2.55, 0, 100);

        #endregion

        #region Constructors

        public AcceleratorPedalPositionD()
            : base(0x49, 1)
        { }

        #endregion
    }
}
