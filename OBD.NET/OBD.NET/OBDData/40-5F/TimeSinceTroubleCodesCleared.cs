using OBD.NET.DataTypes;

namespace OBD.NET.OBDData;

public class TimeSinceTroubleCodesCleared : AbstractOBDData
{
    #region Properties & Fields

    public Minute Time => new((256 * A) + B, 0, 65535);

    #endregion

    #region Constructors

    public TimeSinceTroubleCodesCleared()
        : base(0x4E, 2)
    { }

    #endregion

    #region Methods

    public override string ToString() => Time.ToString();

    #endregion
}