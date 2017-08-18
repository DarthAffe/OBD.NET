namespace OBD.NET.Common.Commands
{
    public class ATCommand
    {
        #region Commands
        // ReSharper disable InconsistentNaming

        //TODO DarthAffe 26.06.2016: Implement all commands

        public static readonly ATCommand RepeatLastCommand = new ATCommand("\r");
        public static readonly ATCommand ResetDevice = new ATCommand("ATZ");
        public static readonly ATCommand ReadVoltage = new ATCommand("ATRV");
        public static readonly ATCommand EchoOn = new ATCommand("ATE1", "^OK$");
        public static readonly ATCommand EchoOff = new ATCommand("ATE0", "^OK$");
        public static readonly ATCommand HeadersOn = new ATCommand("ATH1", "^OK$");
        public static readonly ATCommand HeadersOff = new ATCommand("ATH0", "^OK$");
        public static readonly ATCommand PrintSpacesOn = new ATCommand("ATS1", "^OK$");
        public static readonly ATCommand PrintSpacesOff = new ATCommand("ATS0", "^OK$");
        public static readonly ATCommand LinefeedsOn = new ATCommand("ATL1", "^OK$");
        public static readonly ATCommand LinefeedsOff = new ATCommand("ATL0", "^OK$");
        public static readonly ATCommand SetProtocolAuto = new ATCommand("ATSP0", "^OK$");
        public static readonly ATCommand PrintVersion = new ATCommand("ATI", "^ELM327.*");
        public static readonly ATCommand CloseProtocol = new ATCommand("ATPC");

        // ReSharper restore InconsistentNaming
        #endregion

        #region Properties & Fields

        public string Command { get; }
        public string ExpectedResult { get; }

        #endregion

        #region Constructors

        private ATCommand(string command, string expectedResult = null)
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
}
