using OBD.NET.Communication;
using OBD.NET.Logging;

namespace OBD.NET.Devices
{
    public class STN1170 : ELM327 // Fully compatible device
    {
        //TODO DarthAffe 26.06.2016: Add ST-Commands and stuff

        #region Constructors

        public STN1170(SerialConnection connection, IOBDLogger logger = null)
            : base(connection, logger)
        { }

        #endregion
    }
}
