namespace OBD.NET.Commands;

public class ATCommand
{
    #region Commands
    // ReSharper disable InconsistentNaming

    //TODO DarthAffe 26.06.2016: Implement all commands

    public static readonly ATCommand RepeatLastCommand = new("\r");
    public static readonly ATCommand ResetDevice = new("ATZ");
    public static readonly ATCommand ReadVoltage = new("ATRV");
    public static readonly ATCommand EchoOn = new("ATE1", "^OK$");
    public static readonly ATCommand EchoOff = new("ATE0", "^OK$");
    public static readonly ATCommand HeadersOn = new("ATH1", "^OK$");
    public static readonly ATCommand HeadersOff = new("ATH0", "^OK$");
    public static readonly ATCommand PrintSpacesOn = new("ATS1", "^OK$");
    public static readonly ATCommand PrintSpacesOff = new("ATS0", "^OK$");
    public static readonly ATCommand LinefeedsOn = new("ATL1", "^OK$");
    public static readonly ATCommand LinefeedsOff = new("ATL0", "^OK$");
    public static readonly ATCommand SetProtocolAuto = new("ATSP0", "^OK$");
    public static readonly ATCommand PrintVersion = new("ATI", "^ELM327.*");
    public static readonly ATCommand CloseProtocol = new("ATPC");

    // ReSharper restore InconsistentNaming
    #endregion

    #region Properties & Fields

    public string Command { get; }
    public string? ExpectedResult { get; }

    #endregion

    #region Constructors

    private ATCommand(string command, string? expectedResult = null)
    {
        this.Command = command;
        this.ExpectedResult = expectedResult;
    }

    #endregion

    #region Methods

    public override string ToString() => Command;

    #endregion

    #region Operators

    public static implicit operator string(ATCommand command) => command.ToString();

    #endregion
}