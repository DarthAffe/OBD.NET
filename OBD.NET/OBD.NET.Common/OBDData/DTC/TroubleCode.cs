using System;
using System.Collections.Generic;
using OBD.NET.Common.Extensions;

namespace OBD.NET.Common.OBDData.DTC
{
    public class TroubleCode : AbstractOBDData
    {
        #region Properties & Fields

        private static readonly Dictionary<TroublePart, string> PART_DESCRIPTION = new Dictionary<TroublePart, string>
        {

            { TroublePart.Powertrain, "P" },
            { TroublePart.Chassis, "C" },
            { TroublePart.Body, "B" },
            { TroublePart.Network, "U" },
        };

        public TroublePart TroublePart
        {
            get
            {
                byte data = (byte)(A & 0b11000000);
                switch (data)
                {
                    case 0:
                        return TroublePart.Powertrain;
                    case 0b01000000:
                        return TroublePart.Chassis;
                    case 0b10000000:
                        return TroublePart.Body;
                    case 0b11000000:
                        return TroublePart.Network;
                    default:
                        throw new IndexOutOfRangeException($"Can't parse TroublePart with data {data}");
                }
            }
        }

        public Definition Definition
        {
            get
            {
                byte data = (byte)(A & 0b00110000);
                switch (data)
                {
                    case 0:
                        return Definition.SAEJ2012;
                    case 0b01000000:
                        return Definition.Custom;
                    case 0b10000000:
                        return Definition.Undefined;
                    case 0b11000000:
                        return Definition.Undefined2;
                    default:
                        throw new IndexOutOfRangeException($"Can't parse Definition with data {data}");
                }
            }
        }

        public SpecificPart SpecificPart => (SpecificPart)(A & 0b00001111);

        public string FaultCode => B.ToHexString();

        #endregion

        #region Constructors

        public TroubleCode()
            : base(byte.MaxValue, 2) // DarthAffe 14.09.2017: Trouble-Codes don't have a pid
        { }

        #endregion

        #region Methods

        public override string ToString() => $"{PART_DESCRIPTION[TroublePart]}{(int)Definition}{((byte)SpecificPart).ToHexString()[1]}{FaultCode}";

        #endregion
    }

    #region Data

    public enum TroublePart
    {
        Powertrain = 0,
        Chassis = 1,
        Body = 2,
        Network = 3
    }

    public enum Definition
    {
        SAEJ2012 = 0,
        Custom = 1,
        Undefined = 2,
        Undefined2 = 3
    }

    public enum SpecificPart
    {
        Undefined = 0,
        FuelAndAirMetering = 1,
        FuelAndAirMeteringInjectorCircuit = 2,
        IgnitionSystemOfMisfire = 3,
        AuxiliaryEmissionControls = 4,
        VehicleSpeedControlAndIdleControlSystem = 5,
        ComputerOutputCircuit = 6,
        Transmission = 7,
        Transmission2 = 8,
        Undefined2 = 9,
        Undefined3 = 10,
        Undefined4 = 11,
        Undefined5 = 12,
        Undefined6 = 13,
        Undefined7 = 14,
        Undefined8 = 15,
    }

    #endregion
}
