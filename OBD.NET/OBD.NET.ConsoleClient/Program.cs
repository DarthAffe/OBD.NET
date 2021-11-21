using System;
using System.Threading;
using System.Threading.Tasks;
using OBD.NET.Common.Devices;
using OBD.NET.Common.Extensions;
using OBD.NET.Common.Logging;
using OBD.NET.Common.OBDData;
using OBD.NET.Desktop.Communication;
using OBD.NET.Desktop.Logging;

namespace OBD.NET.ConsoleClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Parameter ComPort needed.");
                return;
            }

            string comPort = args[0];

            using (SerialConnection connection = new SerialConnection(comPort))
            using (ELM327 dev = new ELM327(connection, new OBDConsoleLogger(OBDLogLevel.Debug)))
            {
                dev.SubscribeDataReceived<EngineRPM>((sender, data) => Console.WriteLine("EngineRPM: " + data.Data.Rpm));
                dev.SubscribeDataReceived<VehicleSpeed>((sender, data) => Console.WriteLine("VehicleSpeed: " + data.Data.Speed));

                dev.SubscribeDataReceived<IOBDData>((sender, data) => Console.WriteLine($"PID {data.Data.PID.ToHexString()}: {data.Data}"));

                dev.Initialize();
                dev.RequestData<FuelType>();
                for (int i = 0; i < 5; i++)
                {
                    dev.RequestData<EngineRPM>();
                    dev.RequestData<VehicleSpeed>();
                    Thread.Sleep(1000);
                }
            }
            Console.ReadLine();

            //Async example
            //MainAsync(comPort).Wait();

            //Console.ReadLine();
        }

        /// <summary>
        /// Async example using new RequestDataAsync
        /// </summary>
        /// <param name="comPort">The COM port.</param>
        /// <returns></returns>
        public static async Task MainAsync(string comPort)
        {
            using (SerialConnection connection = new SerialConnection(comPort))
            using (ELM327 dev = new ELM327(connection, new OBDConsoleLogger(OBDLogLevel.Debug)))
            {
                dev.Initialize();
                EngineRPM data = await dev.RequestDataAsync<EngineRPM>();
                Console.WriteLine("Data: " + data.Rpm);
                data = await dev.RequestDataAsync<EngineRPM>();
                Console.WriteLine("Data: " + data.Rpm);
                VehicleSpeed data2 = await dev.RequestDataAsync<VehicleSpeed>();
                Console.WriteLine("Data: " + data2.Speed);
                data = await dev.RequestDataAsync<EngineRPM>();
                Console.WriteLine("Data: " + data.Rpm);
            }
        }
    }
}
