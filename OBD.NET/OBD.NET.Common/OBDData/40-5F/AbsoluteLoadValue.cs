using OBD.NET.DataTypes;

namespace OBD.NET.OBDData
{
    public class AbsoluteLoadValue : AbstractOBDData
    {
        #region Properties & Fields

        public Percent Load => new Percent(((256 * A) + B) / 2.55, 0, 25700);

        #endregion

        #region Constructors

        public AbsoluteLoadValue()
            : base(0x43, 2)
        { }

        #endregion
    }
}
