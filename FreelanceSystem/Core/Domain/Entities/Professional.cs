using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities;

public class Professional : User
{
    public bool ShowServicesOnList { get; set; }

    public async Task HandleClientProposalAsync(Proposal proposal, ProposalAction action)
    {
        if (!proposal.Type.Equals(ProposalType.CLIENT_PROPOSAL))
            throw new InvalidOperationException("You only can handle client proposal types");

        if (proposal.ProfessionalId.Equals(Id))
            throw new InvalidProposalException("You can't handle a proposal that you send to someone");

        await proposal.SetProposalStatusAsync(action);
    }
}