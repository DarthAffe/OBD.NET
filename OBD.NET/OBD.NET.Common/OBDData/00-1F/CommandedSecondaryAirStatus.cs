using System;

namespace OBD.NET.Common.OBDData
{
    public class CommandedSecondaryAirStatus : AbstractOBDData
    {
        #region Properties & Fields

        public CommandedSecondaryAirStatusValue Status => (CommandedSecondaryAirStatusValue)A;

        #endregion

        #region Constructors

        public CommandedSecondaryAirStatus()
            : base(0x12, 1)
        { }

        #endregion

        #region Methods

        public override string ToString() => Status.ToString();

        #endregion

        #region Enum

        /// <summary>
        /// https://en.wikipedia.org/wiki/OBD-II_PIDs#Mode_1_PID_12
        /// </summary>
        [Flags]
        public enum CommandedSecondaryAirStatusValue
        {
            Missing = 0,
            Upstream = 1 << 0,
            DownstreamOfCatalyticConverter = 1 << 1,
            FromTheOutsideAtmosphereOrOff = 1 << 2,
            PumpCommandedOnForDiagnostics = 1 << 3
        }

        #endregion
    }
}
