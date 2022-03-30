namespace OBD.NET.Exceptions;

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
        Result = result;
        ExpectedResult = expectedResult;
    }

    public UnexpectedResultException(string message, string result, string expectedResult)
        : base(message)
    {
        Result = result;
        ExpectedResult = expectedResult;
    }

    public UnexpectedResultException(string message, Exception innerException, string result, string expectedResult)
        : base(message, innerException)
    {
        Result = result;
        ExpectedResult = expectedResult;
    }

    #endregion
}