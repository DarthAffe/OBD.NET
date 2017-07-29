using OBD.NET.Common.DataTypes;

namespace OBD.NET.Common.OBDData
{
    public class EngineRPM : AbstractOBDData
    {
        #region Properties & Fields

        public RevolutionsPerMinute Rpm => new RevolutionsPerMinute(((256 * A) + B) / 4.0, 0, 16383.75);

        #endregion

        #region Constructors

        public EngineRPM()
            : base(0x0C, 2)
        { }

        #endregion

        #region Methods

        public override string ToString() => Rpm.ToString();

        #endregion
    }
}
