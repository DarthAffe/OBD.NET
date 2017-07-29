using OBD.NET.Common.DataTypes;

namespace OBD.NET.Common.OBDData
{
    public class WarmUpsSinceCodesCleared : AbstractOBDData
    {
        #region Properties & Fields

        public Count WarmUps => new Count(A, 0, 255);

        #endregion

        #region Constructors

        public WarmUpsSinceCodesCleared()
            : base(0x30, 1)
        { }

        #endregion

        #region Methods

        public override string ToString() => WarmUps.ToString();

        #endregion
    }
}
