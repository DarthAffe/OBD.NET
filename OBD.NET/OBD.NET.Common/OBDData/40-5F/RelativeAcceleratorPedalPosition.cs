using OBD.NET.Common.DataTypes;

namespace OBD.NET.Common.OBDData
{
    public class RelativeAcceleratorPedalPosition : AbstractOBDData
    {
        #region Properties & Fields

        public Percent PedalPosition => new Percent(A / 2.55, 0, 100);

        #endregion

        #region Constructors

        public RelativeAcceleratorPedalPosition()
            : base(0x5A, 1)
        { }

        #endregion

        #region Methods

        public override string ToString() => PedalPosition.ToString();

        #endregion
    }
}
