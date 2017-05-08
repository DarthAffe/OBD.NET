# OBD.NET
C#-Library to read/write data from/to a car through an ELM327-/STN1170-Adapter

## Projects
* OBD.NET.Common - NetStandard 1.4 Library for platform independent stuff
* OBD.NET.Desktop - Implemenation of SerialConnection on full .NET Framework
* OBD.NET.Universal - Implementation of BluetoothSerialConnection for connecting to Bluetooth Adapter on UWP
* OBD.NET.ConsoleClient - Example client application using SerialConnection on full .NET Framework

## Usage
* Add OBD.NET.Common and OBD.NET.Desktop packages to project
```csharp
class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Parameter ComPort needed.");
            return;
        }

        var comPort = args[0];

        using (SerialConnection connection = new SerialConnection(comPort))
        using (ELM327 dev = new ELM327(connection, new OBDConsoleLogger(OBDLogLevel.Debug)))
        {
            dev.SubscribeDataReceived<EngineRPM>((sender, data) =>
            {
                Console.WriteLine("EngineRPM: " + data.Data.Rpm);
            });

            dev.SubscribeDataReceived<VehicleSpeed>((sender, data) =>
            {
                Console.WriteLine("VehicleSpeed: " + data.Data.Speed);
            });

            dev.Initialize();
            dev.RequestData<FuelType>();
            for (int i = 0; i < 5; i++)
            {
                dev.RequestData<EngineRPM>();
                dev.RequestData<VehicleSpeed>();
                Thread.Sleep(1000);
            }
            Console.ReadLine();
        }
        
    }
}
```


