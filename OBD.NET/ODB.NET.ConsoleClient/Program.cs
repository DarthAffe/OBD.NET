using OBD.NET.Common.Logging;
using OBD.NET.Communication;
using OBD.NET.Devices;
using OBD.NET.Logging;
using OBD.NET.OBDData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ODB.NET.ConsoleClient
{
    /// <summary>
    /// Console test client
    /// </summary>
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
}
