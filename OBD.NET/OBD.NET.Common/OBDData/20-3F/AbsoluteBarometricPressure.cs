using OBD.NET.Common.DataTypes;

namespace OBD.NET.Common.OBDData
{
    public class AbsoluteBarometricPressure : AbstractOBDData
    {
        #region Properties & Fields

        public Kilopascal Pressure => new Kilopascal(A, 0, 255);

        #endregion

        #region Constructors

        public AbsoluteBarometricPressure()
            : base(0x33, 1)
        { }

        #endregion
    }
}
