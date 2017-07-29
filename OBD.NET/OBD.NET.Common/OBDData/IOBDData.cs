namespace OBD.NET.Common.OBDData
{
    public interface IOBDData
    {
        byte PID { get; }

        void Load(string data);
    }
}
