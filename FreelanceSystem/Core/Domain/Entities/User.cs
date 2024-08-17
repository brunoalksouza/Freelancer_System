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
    public bool PerfilIsCompleted { get; set; } = false;
    public DateTime CreatedAt { get; set; }
    public UserRole Role { get; set; }

    public async Task AddReviewAsync(Review review)
    {
        var userAlreadyReviewedThisUser =
            Reviews.Select(r => r.UserFromId == review.UserFromId) == null;

        if (!userAlreadyReviewedThisUser)
            throw new UserAlreadyReviewedAnUserException("The user who wrote the review already reviewed this user");

        Reviews.Add(review);
    }

    public async Task AddNewProposalAsync(Proposal proposal)
    {
        throw new NotImplementedException();
    }

    public async Task SendProposalTo(ProposalTo to, Service service, Proposal proposal)
    {
        throw new NotImplementedException();
    }
}