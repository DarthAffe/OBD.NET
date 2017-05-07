using OBD.NET.DataTypes;

namespace OBD.NET.OBDData
{
    public class ThrottlePosition : AbstractOBDData
    {
        #region Properties & Fields

        public Percent Position => new Percent(A / 2.55, 0, 100);

        #endregion

        #region Constructors

        public ThrottlePosition()
            : base(0x11, 1)
        { }

        #endregion
    }
}
