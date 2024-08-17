namespace Domain.Exceptions;

public class ProfileNotCompletException : Exception
{
    public ProfileNotCompletException() : base("Profile is not complet")
    {
    }
}