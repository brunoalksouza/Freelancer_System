namespace Domain.Exceptions;

public class ProfileIncompleteException : Exception
{
    public ProfileIncompleteException() : base("To execute this command, you need to complete your profile")
    {
    }
}