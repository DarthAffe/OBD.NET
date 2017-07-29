using System;
using System.Threading.Tasks;
using OBD.NET.Common.Communication.EventArgs;

namespace OBD.NET.Common.Communication
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
        /// Gets a value indicating whether this instance uses asynchronous IO
        /// </summary>
        /// <remarks>
        /// Has to be set to true if asynchronous IO is supported. 
        /// If true async methods have to be implemented
        /// </remarks>
        bool IsAsync { get; }

        /// <summary>
        /// Occurs when a full line was received
        /// </summary>
        event EventHandler<DataReceivedEventArgs> DataReceived;

        /// <summary>
        /// Connects the serial port.
        /// </summary>
        void Connect();

        /// <summary>
        /// Connects the serial port asynchronous
        /// </summary>
        /// <returns></returns>
        Task ConnectAsync();

        /// <summary>
        /// Writes the specified data to the serial connection
        /// </summary>
        /// <param name="data">The data.</param>
        void Write(byte[] data);

        /// <summary>
        /// Writes the specified data to the serial connection asynchronous
        /// </summary>
        /// <param name="data">The data.</param>
        Task WriteAsync(byte[] data);
    }
}
