using System;

namespace Domain.Exceptions;

public class LowPriceException : Exception
{
    public LowPriceException(string? message) : base(message)
    {
    }
}
