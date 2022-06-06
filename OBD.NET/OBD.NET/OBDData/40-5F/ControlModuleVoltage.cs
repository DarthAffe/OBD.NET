using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class ControlModuleVoltage : AbstractOBDData
{
    #region Properties & Fields

    public Volt Voltage => new(((256 * A) + B) / 1000.0, 0, 65.535);

    #endregion

    #region Constructors

    public ControlModuleVoltage()
        : base(0x42, 2)
    { }

    #endregion

    #region Methods

    public override string ToString() => Voltage.ToString();

    #endregion
}