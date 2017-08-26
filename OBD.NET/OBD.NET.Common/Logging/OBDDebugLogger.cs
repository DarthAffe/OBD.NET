using System;
using System.Diagnostics;

namespace OBD.NET.Common.Logging
{
    /// <summary>
    /// Simple debug logger
    /// </summary>
    /// <seealso cref="IOBDLogger" />
    public class OBDDebugLogger : IOBDLogger
    {

        #region Properties & Fields

        public OBDLogLevel LogLevel { get; set; }

        #endregion

        #region Constructors

        public OBDDebugLogger(OBDLogLevel level = OBDLogLevel.None)
        {
            this.LogLevel = level;
        }

        #endregion

        #region Methods

        public void WriteLine(string text, OBDLogLevel level)
        {
            if (LogLevel == OBDLogLevel.None) return;

            if ((int)level <= (int)LogLevel)
                Debug.WriteLine($"{DateTime.Now:G} -  {level} -  {text}");
        }

        #endregion
    }
}
