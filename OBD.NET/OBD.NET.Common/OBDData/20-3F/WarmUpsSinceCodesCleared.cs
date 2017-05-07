using OBD.NET.DataTypes;

namespace OBD.NET.OBDData
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
    }
}
