using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities;

public class Client : User
{
    public List<Service> Services { get; private set; }

    public Client()
    {
        Role = UserRole.CLIENT;
    }

    public async Task CreateNewServiceAsync(Service service)
    {
        VerifyProfileIsCompleteAsync();
        Services.Add(service);
    }
    public async Task HandleProposalAsync(Proposal proposal, ProposalAction action)
    {
        VerifyProfileIsCompleteAsync();
        if (!proposal.Type.Equals(ProposalType.PROFESSIONAL_PROPOSAL))
            throw new InvalidOperationException("You only can handle professional proposal types");

        if (proposal.ProfessionalId.Equals(Id))
            throw new InvalidProposalException("You can't handle a proposal that you send to someone");

        await proposal.SetProposalStatusAsync(action);
    }
}