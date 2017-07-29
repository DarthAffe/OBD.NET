namespace OBD.NET.Common.Communication.EventArgs
{
    /// <summary>
    /// Event args for receiving serial data
    /// </summary>
    public class DataReceivedEventArgs : System.EventArgs
    {
        #region Properties & Fields

        /// <summary>
        /// Count of valid data bytes in the buffer
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Data buffer holding the bytes
        /// </summary>
        public byte[] Data { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataReceivedEventArgs"/> class.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="data">The data.</param>
        public DataReceivedEventArgs(int count, byte[] data)
        {
            this.Count = count;
            this.Data = data;
        }

        #endregion
    }
}
