namespace OBD.NET.OBDData
{
    public class MaximumValueForAirFlowRate : AbstractOBDData
    {
        #region Properties & Fields

        public int Value => A * 10;

        #endregion

        #region Constructors

        public MaximumValueForAirFlowRate()
            : base(0x50, 4)
        { }

        #endregion
    }
}
