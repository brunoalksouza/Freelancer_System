namespace Domain.Exceptions;

public class ProposalStatusException : Exception
{
    public ProposalStatusException(string message) : base(message)
    {
    }
}