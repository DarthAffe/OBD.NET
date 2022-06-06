using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class CommandedThrottleActuator : AbstractOBDData
{
    #region Properties & Fields

    public Percent Value => new(A / 2.55, 0, 100);

    #endregion

    #region Constructors

    public CommandedThrottleActuator()
        : base(0x4C, 1)
    { }

    #endregion

    #region Methods

    public override string ToString() => Value.ToString();

    #endregion
}