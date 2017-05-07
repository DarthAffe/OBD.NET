using System;
using System.Text;
using System.Threading;

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
        event EventHandler<string> MessageReceived;


        /// <summary>
        /// Connects the serial port.
        /// </summary>
        void Connect();


        /// <summary>
        /// Writes the specified text to the serial connection
        /// </summary>
        /// <param name="text">The text.</param>
        void Write(string text);
        
    }
}
