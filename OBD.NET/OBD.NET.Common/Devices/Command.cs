using System;
using System.Collections.Generic;
using System.Text;

namespace OBD.NET.Common.Devices
{
    /// <summary>
    /// Class used for queued command
    /// </summary>
    public class QueuedCommand
    {

        /// <summary>
        /// Initializes a new instance
        /// </summary>
        /// <param name="commandText"></param>
        public QueuedCommand(string commandText)
        {
            CommandResult = new CommandResult();
            CommandText = commandText;
        }

        public string CommandText { get; set; }

        public CommandResult CommandResult { get; }
    }
}
