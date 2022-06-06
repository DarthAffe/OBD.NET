namespace OBD.NET.Commands;

public class STCommand
{
    #region Values
    // ReSharper disable InconsistentNaming

    //TODO DarthAffe 19.03.2017: Implement all commands

    internal static readonly STCommand AddPassFilter = new("STFAP");
    internal static readonly STCommand AddBlockFilter = new("STFAB");
    internal static readonly STCommand AddFlowControlFilter = new("STFAFC");
    internal static readonly STCommand ClearPassFilters = new("STFCP");
    internal static readonly STCommand ClearBlockFilters = new("STFCB");
    internal static readonly STCommand ClearFlowControlFilters = new("STFCFC");
    internal static readonly STCommand Monitor = new("STM");
    internal static readonly STCommand MonitorAll = new("STMA");

    // ReSharper restore InconsistentNaming
    #endregion

    #region Properties & Fields

    public string Command { get; }

    #endregion

    #region Constructors

    protected STCommand(string command)
    {
        this.Command = command;
    }

    #endregion

    #region Methods

    public override string ToString() => Command;

    #endregion

    #region Operators

    public static implicit operator string(STCommand command) => command.ToString();

    #endregion
}