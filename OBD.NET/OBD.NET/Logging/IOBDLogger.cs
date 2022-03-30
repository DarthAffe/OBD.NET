namespace OBD.NET.Logging;

public interface IOBDLogger
{
    void WriteLine(string text, OBDLogLevel level);
}