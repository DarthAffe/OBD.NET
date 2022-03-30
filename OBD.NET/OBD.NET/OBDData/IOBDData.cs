namespace OBD.NET.OBDData;

public interface IOBDData
{
    byte PID { get; }

    void Load(string data);
}