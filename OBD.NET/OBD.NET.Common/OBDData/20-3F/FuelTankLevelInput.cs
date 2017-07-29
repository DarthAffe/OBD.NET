using OBD.NET.Common.DataTypes;

namespace OBD.NET.Common.OBDData
{
    public class FuelTankLevelInput : AbstractOBDData
    {
        #region Properties & Fields

        public Percent Level => new Percent(A / 2.55, 0, 100);

        #endregion

        #region Constructors

        public FuelTankLevelInput()
            : base(0x2F, 1)
        { }

        #endregion

        #region Methods

        public override string ToString() => Level.ToString();

        #endregion
    }
}
