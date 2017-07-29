using System;

namespace OBD.NET.Common.Exceptions
{
    public class UnexpectedResultException : Exception
    {
        #region Properties & Fields

        public string Result { get; }
        public string ExpectedResult { get; }

        #endregion

        #region Constructors

        public UnexpectedResultException(string result, string expectedResult)
            : this($"Unexpected result '{result}'. Expected was '{expectedResult}'", result, expectedResult)
        {
            this.Result = result;
            this.ExpectedResult = expectedResult;
        }

        public UnexpectedResultException(string message, string result, string expectedResult)
            : base(message)
        {
            this.Result = result;
            this.ExpectedResult = expectedResult;
        }

        public UnexpectedResultException(string message, Exception innerException, string result, string expectedResult)
            : base(message, innerException)
        {
            this.Result = result;
            this.ExpectedResult = expectedResult;
        }

        #endregion
    }
}
