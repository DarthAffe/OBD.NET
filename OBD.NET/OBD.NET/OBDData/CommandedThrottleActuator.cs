namespace OBD.NET.OBDData
{
    public class CommandedThrottleActuator : AbstractOBDData
    {
        #region Properties & Fields

        public double Value => A / 2.55;

        #endregion

        #region Constructors

        public CommandedThrottleActuator()
            : base(0x4C, 1)
        { }

        #endregion
    }
}
