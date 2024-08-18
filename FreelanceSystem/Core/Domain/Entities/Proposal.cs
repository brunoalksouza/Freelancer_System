using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities;

public class Proposal
{
    public Guid Id { get; set; }
    public Guid? ProfessionalId { get; set; }
    public Guid? ClientId { get; set; }
    public Guid ServiceId { get; set; }
    public String Comment { get; set; }
    public float Price { get; set; }
    public ProposalType Type { get; set; }
    public ProposalStatus Status { get; set; }

    public Proposal(Guid serviceId, string comment, float price, ProposalType type,
        Guid? professionalId, Guid? clientId)
    {
        if (type.Equals(ProposalType.PROFESSIONAL_PROPOSAL))
        {
            if (professionalId.Equals(null))
                throw new ProposalTypeException("You need to set professional ID");
        }
        else if (type.Equals(ProposalType.CLIENT_PROPOSAL))
        {
            if (clientId.Equals(null))
                throw new ProposalTypeException("You need to set client ID");
        }

        var minimumPrice = 5.0;

        if (price < minimumPrice)
            throw new InvalidProposalException("Price must be greater than or equal to " + minimumPrice);

        ProfessionalId = professionalId;
        ClientId = clientId;
        ServiceId = serviceId;
        Comment = comment;
        Price = price;
        Type = type;
    }

    public void SetProposalStatus(ProposalStatus status) => Status = status;
}