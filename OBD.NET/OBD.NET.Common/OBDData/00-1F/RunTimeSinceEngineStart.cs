using OBD.NET.Common.DataTypes;

namespace OBD.NET.Common.OBDData
{
    public class RunTimeSinceEngineStart : AbstractOBDData
    {
        #region Properties & Fields

        public Second Runtime => new Second((256 * A) + B, 0, 65535);

        #endregion

        #region Constructors

        public RunTimeSinceEngineStart()
            : base(0x1F, 2)
        { }

        #endregion

        #region Methods

        public override string ToString() => Runtime.ToString();

        #endregion
    }
}
