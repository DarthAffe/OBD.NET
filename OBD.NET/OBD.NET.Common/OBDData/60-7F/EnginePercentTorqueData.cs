using OBD.NET.Common.DataTypes;

namespace OBD.NET.Common.OBDData
{
    public class EnginePercentTorqueData : AbstractOBDData
    {
        #region Properties & Fields

        public Percent Idle => new Percent(A - 125, -125, 125);
        public Percent EnginePoint1 => new Percent(B - 125, -125, 125);
        public Percent EnginePoint2 => new Percent(C - 125, -125, 125);
        public Percent EnginePoint3 => new Percent(D - 125, -125, 125);
        public Percent EnginePoint4 => new Percent(E - 125, -125, 125);

        #endregion

        #region Constructors

        public EnginePercentTorqueData()
            : base(0x64, 5)
        { }

        #endregion

        #region Methods

        public override string ToString() => Idle.ToString();

        #endregion
    }
}
