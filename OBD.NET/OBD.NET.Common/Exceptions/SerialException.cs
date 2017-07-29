using System;

namespace OBD.NET.Common.Exceptions
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


        #endregion
    }
}
