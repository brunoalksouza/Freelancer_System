namespace Domain.Exceptions;

public class UserAlreadyReviewedAnUserException : Exception
{
    public UserAlreadyReviewedAnUserException(string message) : base(message)
    {
    }
}