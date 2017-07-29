using System.Diagnostics;

namespace OBD.NET.Common.Logging
{
    /// <summary>
    /// Simple debug logger
    /// </summary>
    /// <seealso cref="IOBDLogger" />
    public class OBDDebugLogger : IOBDLogger
    {
        #region Methods

        public void WriteLine(string text, OBDLogLevel level) => Debug.WriteLine($"{level}: {text}");

        #endregion
    }
}
