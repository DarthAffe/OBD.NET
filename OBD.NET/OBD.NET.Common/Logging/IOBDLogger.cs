namespace OBD.NET.Common.Logging
{
    public interface IOBDLogger
    {
        void WriteLine(string text, OBDLogLevel level);
    }
}
