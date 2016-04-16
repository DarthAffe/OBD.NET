using System.IO;

namespace OBD.NET.OBDData
{
    public interface IOBDData
    {
        int PID { get; }

        void Read(Stream stream);
    }
}
