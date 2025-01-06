using System;

namespace LogForU.Core.Exceptions;

public class InvalidDateTimeFormatException : Exception
{
    private const string DefaultMessage =
        "Invalid DateTime format";

    public InvalidDateTimeFormatException()
        : base(DefaultMessage)
    {
    }

    public InvalidDateTimeFormatException(string message)
        : base(message)
    {
    }
}
