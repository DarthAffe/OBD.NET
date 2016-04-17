namespace OBD.NET.OBDData
{
    public class AbsoluteBarometricPressure : AbstractOBDData
    {
        #region Properties & Fields

        public int Pressure => A;

        #endregion

        #region Constructors

        public AbsoluteBarometricPressure()
            : base(0x33, 1)
        { }

        #endregion
    }
}
