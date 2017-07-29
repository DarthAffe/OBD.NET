using System;

namespace OBD.NET.Common.OBDData
{
    public class FuelSystemStatus : AbstractOBDData
    {
        #region Properties & Fields

        public FuelSystemStatusValue StatusSystem1 => (FuelSystemStatusValue)A;
        public FuelSystemStatusValue StatusSystem2 => (FuelSystemStatusValue)B;

        #endregion

        #region Constructors

        public FuelSystemStatus()
            : base(0x03, 2)
        { }

        #endregion

        #region Methods

        public override string ToString() => StatusSystem1.ToString();

        #endregion

        #region Enums

        /// <summary>
        /// https://en.wikipedia.org/wiki/OBD-II_PIDs#Mode_1_PID_03
        /// </summary>
        [Flags]
        public enum FuelSystemStatusValue
        {
            Missing = 0,
            OpenLoopDueToInsufficientEngineTemperature = 1 << 0,
            ClosedLoopUsingOxygenSensorFeedbackToDetermineFuelMix = 1 << 1,
            OpenLoopDueToEngineLoadOrFuelCutDueToDeceleration = 1 << 2,
            OpenLoopDueToSystemFailure = 1 << 3,
            ClosedLoopUsingAtLeastOneOxygenSensorButThereIsAFaultInTheFeedbackSystem = 1 << 4
        }

        #endregion
    }
}
