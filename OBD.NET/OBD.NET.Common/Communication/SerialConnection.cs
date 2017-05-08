using OBD.NET.Common.Communication.EventArgs;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OBD.NET.Communication
{
    /// <summary>
    /// Serial connection interface
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface ISerialConnection : IDisposable
    {
        /// <summary>
        /// Gets a value indicating whether this instance is open.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is open; otherwise, <c>false</c>.
        /// </value>
        bool IsOpen { get; }

        /// <summary>
        /// Occurs when a full line was received
        /// </summary>
        event EventHandler<DataReceivedEventArgs> DataReceived;


        /// <summary>
        /// Connects the serial port.
        /// </summary>
        bool Connect();

        /// <summary>
        /// Connects the serial port async
        /// </summary>
        /// <returns></returns>
        Task<bool> ConnectAsync();


        /// <summary>
        /// Writes the specified data to the serial connection
        /// </summary>
        /// <param name="text">The text.</param>
        void Write(byte[] data);

        /// <summary>
        /// Writes the specified data to the serial connection async
        /// </summary>
        /// <param name="text">The text.</param>
        Task WriteAsync(byte[] data);

    }
}
