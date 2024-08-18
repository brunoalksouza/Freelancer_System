using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities;

public abstract class User
{
    public Guid Id { get; set; }
    public String Name { get; set; }
    public String Phone { get; set; }
    public String Email { get; set; }
    public String PasswordHash { get; set; }
    public String ProfilePicture { get; set; }
    public List<Review> Reviews { get; set; }
    public List<Proposal> Proposals { get; set; }
    public bool ProfileIsCompleted { get; set; } = false;
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public UserRole Role { get; set; }

    public async Task AddReviewAsync(Review review)
    {
        VerifyProfileIsCompleteAsync();
        var userAlreadyReviewedThisUser =
            Reviews.Select(r => r.UserFromId == review.UserFromId) == null;

        if (!userAlreadyReviewedThisUser)
            throw new UserAlreadyReviewedAnUserException("The user who wrote the review already reviewed this user");

        Reviews.Add(review);
    }

    public async Task AddNewProposalAsync(Proposal proposal)
    {
        VerifyProfileIsCompleteAsync();
        var userAlreadyProposal = false;
        
        if (proposal.Type.Equals(ProposalType.PROFESSIONAL_PROPOSAL))
        {
            if (Proposals.Any(p => p.ProfessionalId.Equals(Id)))
                throw new InvalidProposalException("You can't send a proposal to yourself");
            
            userAlreadyProposal = Proposals.Any(p =>
                p.ProfessionalId.Equals(proposal.ProfessionalId) &&
                p.ServiceId.Equals(proposal.ServiceId)
            );
        }
        else if (proposal.Type.Equals(ProposalType.CLIENT_PROPOSAL))
        {
            if (Proposals.Any(p => p.ClientId.Equals(Id)))
                throw new InvalidProposalException("You can't send a proposal to yourself");

            userAlreadyProposal = Proposals.Any(p =>
                p.ClientId.Equals(proposal.ClientId) &&
                p.ServiceId.Equals(proposal.ServiceId)
            );
        }

        if (userAlreadyProposal)
            throw new InvalidProposalException("You already have a proposal for this service");

        proposal.Status = ProposalStatus.PENDING;
        Proposals.Add(proposal);
    }

    public async Task VerifyProfileIsCompleteAsync()
    {
        if (ProfileIsCompleted == false)
            throw new ProfileIncompleteException();
    }
    
}