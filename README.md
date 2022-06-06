# OBD.NET
C#-Library to read/write data from/to a car through an ELM327-/STN1170-Adapter

## Projects
* [OBD.NET](https://www.nuget.org/packages/OBD.NET) - OBD-II implementation in .NET 6/5 and .NET Framework 4.8
* ConsoleClient - Example client application using SerialConnection, running with .NET 6

## Usage
* Add the `OBD.NET` package to project
```csharp

public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Parameter ComPort needed.");

            IEnumerable<string> availablePorts = SerialConnection.GetAvailablePorts();

            Console.WriteLine("\nAvailable ports:");

            foreach (string port in availablePorts)
            {
                Console.WriteLine(port);
            }

            return;
        }

        string comPort = args[0];

        using SerialConnection connection = new SerialConnection(comPort);
        using ELM327 dev = new ELM327(connection, new OBDConsoleLogger(OBDLogLevel.Debug));

        dev.SubscribeDataReceived<EngineRPM>((sender, data) => Console.WriteLine("EngineRPM: " + data.Data.Rpm));
        dev.SubscribeDataReceived<VehicleSpeed>((sender, data) => Console.WriteLine("VehicleSpeed: " + data.Data));

        dev.SubscribeDataReceived<IOBDData>((sender, data) => Console.WriteLine($"PID {data.Data.PID.ToHexString()}: {data.Data}"));

        dev.Initialize();
        dev.RequestData<FuelType>();

        for (int i = 0; i < 5; i++)
        {
            dev.RequestData<EngineRPM>();
            dev.RequestData<VehicleSpeed>();
            Thread.Sleep(1000);
        }

        Console.ReadLine();

        //Async example
        // MainAsync(comPort).Wait();

        //Console.ReadLine();
    }

    /// <summary>
    /// Async example using new RequestDataAsync
    /// </summary>
    /// <param name="comPort">The COM port.</param>
    /// <returns></returns>
    public static async Task MainAsync(string comPort)
    {
        using SerialConnection connection = new SerialConnection(comPort);
        using ELM327 dev = new ELM327(connection, new OBDConsoleLogger(OBDLogLevel.Debug));

        dev.Initialize();

        EngineRPM engineRpm = await dev.RequestDataAsync<EngineRPM>();
        Console.WriteLine("Data: " + engineRpm.Rpm);

        engineRpm = await dev.RequestDataAsync<EngineRPM>();
        Console.WriteLine("Data: " + engineRpm.Rpm);

        VehicleSpeed vehicleSpeed = await dev.RequestDataAsync<VehicleSpeed>();
        Console.WriteLine("Data: " + vehicleSpeed.Speed);

        engineRpm = await dev.RequestDataAsync<EngineRPM>();
        Console.WriteLine("Data: " + engineRpm.Rpm);
    }
}
```
