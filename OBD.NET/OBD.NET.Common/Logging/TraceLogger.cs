using OBD.NET.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OBD.NET.Common.Logging
{
    /// <summary>
    /// Simple debug logger
    /// </summary>
    /// <seealso cref="OBD.NET.Logging.IOBDLogger" />
    public class OBDDebugLogger : IOBDLogger
    {
        public void WriteLine(string text, OBDLogLevel level)
        {
            Debug.WriteLine($"{level}: {text}");
        }
    }
}
