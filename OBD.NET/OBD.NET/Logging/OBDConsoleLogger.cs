using System;

namespace OBD.NET.Logging;

/// <summary>
/// Simple console logger
/// </summary>
/// <seealso cref="IOBDLogger" />
public class OBDConsoleLogger : IOBDLogger
{
    #region Properties & Fields

    public OBDLogLevel LogLevel { get; set; }

    #endregion

    #region Constructors

    public OBDConsoleLogger(OBDLogLevel level = OBDLogLevel.None)
    {
        this.LogLevel = level;
    }

    #endregion

    #region Methods

    public void WriteLine(string text, OBDLogLevel level)
    {
        if (LogLevel == OBDLogLevel.None) return;

        if ((int)level <= (int)LogLevel)
            Console.WriteLine($"{DateTime.Now:G} -  {level} -  {text}");
    }

    #endregion
}