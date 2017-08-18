namespace OBD.NET.Common.Devices
{
    /// <summary>
    /// Class used for queued command
    /// </summary>
    public class QueuedCommand
    {
        #region Properties & Fields

        public string CommandText { get; private set; }

        public CommandResult CommandResult { get; }

        #endregion

        #region Constructors

        public QueuedCommand(string commandText)
        {
            this.CommandText = commandText;

            CommandResult = new CommandResult();
        }

        #endregion
    }
}
