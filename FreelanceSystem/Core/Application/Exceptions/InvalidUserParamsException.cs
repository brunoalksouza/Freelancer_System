using System;

namespace Application.Exceptions;

public class InvalidUserParamsException : Exception
{
    public InvalidUserParamsException(string? message) : base(message)
    {
    }
}
