using Domain.Enums;

namespace Domain.Entities;

public class Proposal
{
    public Guid Id { get; set; }
    public Guid? ProfessionalId { get; set; }
    public Guid? ClientId { get; set; }
    public Guid ServiceId { get; set; }
    public String Comment { get; set; }
    public float Price { get; set; }
    public ProposalStatus Status { get; set; }
    public ProposalType Type { get; set; }
}