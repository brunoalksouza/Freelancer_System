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
    public List<ProposalComment> ProposalComments { get; set; }
    public ProposalType Type { get; set; }
    public ProposalStatus Status { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
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

        var minimumPrice = 25.0;

        if (price < minimumPrice)
            throw new InvalidProposalException("Price must be greater than or equal to " + minimumPrice);

        ProfessionalId = professionalId;
        ClientId = clientId;
        ServiceId = serviceId;
        Comment = comment;
        Price = price;
        Type = type;
    }

    public async Task SetProposalStatusAsync(ProposalAction action)
    {
        this.Status = (this.Status, action) switch
        {
            (ProposalStatus.PENDING, ProposalAction.ACCEPT) => ProposalStatus.CONFIRMED,
            (ProposalStatus.PENDING, ProposalAction.RECUSE) => ProposalStatus.RECUSED,
            (ProposalStatus.PENDING, ProposalAction.RESPONSE_TO_PROFESSIONAL) => ProposalStatus.WAITING_PROFESSIONAL_RESPONSE,
            (ProposalStatus.PENDING, ProposalAction.QUESTION_TO_CLIENT) => ProposalStatus.WAITING_CLIENT_RESPONSE,

            (ProposalStatus.CANCELLED, ProposalAction.ACCEPT) => throw new ProposalStatusException("You can't accept a proposal that was cancelled"),
            (ProposalStatus.CANCELLED, ProposalAction.RECUSE) => throw new ProposalStatusException("You can't recuse a proposal that was cancelled"),
            (ProposalStatus.CANCELLED, ProposalAction.RESPONSE_TO_PROFESSIONAL) => throw new ProposalStatusException("You can't send a response to the professional when the proposal is cancelled"),
            (ProposalStatus.CANCELLED, ProposalAction.QUESTION_TO_CLIENT) => throw new ProposalStatusException("You can't send a question to the client when the proposal is already cancelled"),

            (ProposalStatus.CONFIRMED, ProposalAction.ACCEPT) => ProposalStatus.CONFIRMED,
            (ProposalStatus.CONFIRMED, ProposalAction.RECUSE) => throw new ProposalStatusException("You can't recuse a proposal that was accepted"),
            (ProposalStatus.CONFIRMED, ProposalAction.RESPONSE_TO_PROFESSIONAL) => throw new ProposalStatusException("You can't send a response to the professional when the proposal is accepted"),
            (ProposalStatus.CONFIRMED, ProposalAction.QUESTION_TO_CLIENT) => throw new ProposalStatusException("You can't send a question to the client when the proposal is already accepted"),

            (ProposalStatus.RECUSED, ProposalAction.ACCEPT) => throw new ProposalStatusException("You can't accept a proposal that was recused"),
            (ProposalStatus.RECUSED, ProposalAction.RECUSE) => throw new ProposalStatusException("You can't recuse a proposal that was recused"),
            (ProposalStatus.RECUSED, ProposalAction.RESPONSE_TO_PROFESSIONAL) => throw new ProposalStatusException("You can't send a response to the professional when the proposal is recused"),
            (ProposalStatus.RECUSED, ProposalAction.QUESTION_TO_CLIENT) => throw new ProposalStatusException("You can't send a question to the client when the proposal is already recused"),

        };
    }
}