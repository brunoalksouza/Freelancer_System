using Domain.Enums;

namespace Domain.Entities;

public class Client : User
{
    public async Task AddNewServiceAsync(Service service)
    {
        throw new NotImplementedException();
    }

    public async Task HandleProposalAsync(Proposal proposal, ProposalAction action)
    {
        throw new NotImplementedException();
    }

    public async Task SendProposalToProfessional(Professional professional, Proposal proposal)
    {
        throw new NotImplementedException();
    }
}