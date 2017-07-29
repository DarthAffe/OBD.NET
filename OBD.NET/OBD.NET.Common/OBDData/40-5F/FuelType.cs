namespace OBD.NET.Common.OBDData
{
    public class FuelType : AbstractOBDData
    {
        #region Properties & Fields

        public FuelTypeValue Type => (FuelTypeValue)A;

        #endregion

        #region Constructors

        public FuelType()
            : base(0x51, 1)
        { }

        #endregion

        #region Methods

        public override string ToString() => Type.ToString();

        #endregion

        #region Enum

        public enum FuelTypeValue
        {
            NotAvailable = 0,
            Gasoline = 1,
            Methanol = 2,
            Ethanol = 3,
            Diesel = 4,
            LPG = 5,
            CNG = 6,
            Propane = 7,
            Electric = 8,
            BifuelGasoline = 9,
            BifuelMethanol = 10,
            BifuelEthanol = 11,
            BifuelLPG = 12,
            BifuelCNG = 13,
            BifuelPropane = 14,
            BifuelElectricity = 15,
            BifuelElectricAndCombustionEngine = 16,
            HybridGasoline = 17,
            HybridEthanol = 18,
            HybridDiesel = 19,
            HybridElectric = 20,
            HybridElectricAndCombustionEngine = 21,
            HybridRegenerative = 22,
            BifuelDiesel = 23
        }

        #endregion
    }
}
