using Domain.Enums;

namespace Domain.Entities;

public class Professional : User
{
    public bool ShowServicesOnList { get; set; }

    public async Task HandleClientProposalAsync(Proposal proposal, ProposalAction action)
    {
        throw new NotImplementedException();
    }
}