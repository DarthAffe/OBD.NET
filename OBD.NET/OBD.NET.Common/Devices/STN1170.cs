using OBD.NET.Common.Commands;
using OBD.NET.Common.Communication;
using OBD.NET.Common.Logging;

namespace OBD.NET.Common.Devices
{
    public class STN1170 : ELM327 // Fully compatible device
    {
        #region Constructors

        public STN1170(ISerialConnection connection, IOBDLogger logger = null)
            : base(connection, logger)
        { }

        #endregion

        #region Methods

        /// <summary>
        /// Sends the ST command.
        /// </summary>
        /// <param name="command">The command.</param>
        public virtual void SendCommand(STCommand command) => SendCommand(command.Command);

        #endregion
    }
}
