using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities;

public class Client : User
{
    public async Task AddNewServiceAsync(Service service)
    {
        throw new NotImplementedException();
    }

    public async Task HandleProposalAsync(Proposal proposal, ProposalAction action)
    {
        if (!proposal.Type.Equals(ProposalType.PROFESSIONAL_PROPOSAL))
            throw new InvalidOperationException("You only can handle professional proposal types");

        if (proposal.ProfessionalId.Equals(Id))
            throw new InvalidProposalException("You can't handle a proposal that you send to someone");

        await proposal.SetProposalStatusAsync(action);
    }

    public async Task SendProposalToProfessional(Professional professional, Proposal proposal)
    {
        throw new NotImplementedException();
    }
}