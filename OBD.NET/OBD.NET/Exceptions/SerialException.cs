using System;
using System.Runtime.Serialization;

namespace OBD.NET.Exceptions
{
    public class SerialException : Exception
    {
        #region Constructors

        public SerialException()
        { }

        public SerialException(string message)
            : base(message)
        { }

        public SerialException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected SerialException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        #endregion
    }
}
