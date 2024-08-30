using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities;

public abstract class User
{
    public Guid Id { get; set; }
    public String Name { get; set; }
    public String CPF { get; set; }
    public String Phone { get; set; }
    public String Email { get; set; }
    public String PasswordHash { get; set; }
    public String ProfilePicture { get; set; }
    public DateTime BirthDate { get; set; }
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

    public bool ValidCPF()
    {
        if (CPF == null) return false;

        CPF = new string(CPF.Where(char.IsDigit).ToArray());

        if (CPF.Length != 11) return false;

        if (CPF.Distinct().Count() == 1) return false;

        int[] mult1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] mult2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string theresCPF = CPF.Substring(0, 9);
        int sum = 0;

        for (int i = 0; i < 9; i++)
            sum += int.Parse(theresCPF[i].ToString()) * mult1[i];

        int resto = sum % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        string digito = resto.ToString();
        theresCPF = theresCPF + digito;
        sum = 0;

        for (int i = 0; i < 10; i++)
            sum += int.Parse(theresCPF[i].ToString()) * mult2[i];

        resto = sum % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = digito + resto.ToString();

        return CPF.EndsWith(digito);
    }

    public bool IsEighteenYearsOld()
    {
        var now = DateTime.Now;
        var age = now.Year - BirthDate.Year;
        if (age < 18)
        {
            return false;
        }

        return true;
    }
}