using OBD.NET.DataTypes;

namespace OBD.NET.OBDData
{
    public class AcceleratorPedalPositionF : AbstractOBDData
    {
        #region Properties & Fields

        public Percent Position => new Percent(A / 2.55, 0, 100);

        #endregion

        #region Constructors

        public AcceleratorPedalPositionF()
            : base(0x4B, 1)
        { }

        #endregion
    }
}
