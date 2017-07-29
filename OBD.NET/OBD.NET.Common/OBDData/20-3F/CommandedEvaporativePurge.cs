using OBD.NET.Common.DataTypes;

namespace OBD.NET.Common.OBDData
{
    public class CommandedEvaporativePurge : AbstractOBDData
    {
        #region Properties & Fields

        public Percent Purge => new Percent(A / 2.55, 0, 100);

        #endregion

        #region Constructors

        public CommandedEvaporativePurge()
            : base(0x2E, 1)
        { }

        #endregion

        #region Methods

        public override string ToString() => Purge.ToString();

        #endregion
    }
}
