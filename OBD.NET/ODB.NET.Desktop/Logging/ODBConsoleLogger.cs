using OBD.NET.Logging;
using System;
using System.Diagnostics;

namespace OBD.NET.Common.Logging
{
    /// <summary>
    /// Simple console logger
    /// </summary>
    /// <seealso cref="OBD.NET.Logging.IOBDLogger" />
    public class OBDConsoleLogger : IOBDLogger
    {
        public OBDLogLevel LogLevel { get; set; }

        public OBDConsoleLogger()
        {
            LogLevel = OBDLogLevel.None;
        }

        public OBDConsoleLogger(OBDLogLevel level)
        {
            LogLevel = level;
        }

        public void WriteLine(string text, OBDLogLevel level)
        {
            if (LogLevel == OBDLogLevel.None) return;

            if((int)level >= (int)LogLevel)
            { 
                Console.WriteLine($"{DateTime.Now.ToString()} -  {level} -  {text}");
            }
        }
    }
}
