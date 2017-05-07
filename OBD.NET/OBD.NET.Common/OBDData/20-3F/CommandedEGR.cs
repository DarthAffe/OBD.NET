using OBD.NET.DataTypes;

namespace OBD.NET.OBDData
{
    public class CommandedEGR : AbstractOBDData
    {
        #region Properties & Fields

        public Percent EGR => new Percent(A / 2.55, 0, 100);

        #endregion

        #region Constructors

        public CommandedEGR()
            : base(0x2C, 1)
        { }

        #endregion
    }
}
