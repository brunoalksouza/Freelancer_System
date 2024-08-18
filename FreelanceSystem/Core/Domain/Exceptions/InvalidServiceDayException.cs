namespace Domain.Exceptions;

public class InvalidServiceDayException : Exception
{
    public InvalidServiceDayException(string message) : base(message)
    {
    }
}