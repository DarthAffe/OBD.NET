using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class MaximumValues : AbstractOBDData
{
    #region Properties & Fields

    public Ratio FuelAirEquivalenceRatio => new(A, 0, 255);
    public Volt OxygenSensorVoltage => new(B, 0, 255);
    public Milliampere OxygenSensorCurrent => new(C, 0, 255);
    public Kilopascal IntakeManifoldAbsolutePressure => new(D * 10, 0, 2550);

    #endregion

    #region Constructors

    public MaximumValues()
        : base(0x4F, 4)
    { }

    #endregion

    #region Methods

    public override string ToString() => FuelAirEquivalenceRatio.ToString();

    #endregion
}