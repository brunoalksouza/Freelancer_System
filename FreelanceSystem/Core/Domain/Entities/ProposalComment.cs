using System;

namespace Domain.Entities;

public class ProposalComment
{
    public Guid Id { get; set; }
    public string Message { get; set; }
    public Guid UserId { get; set; }
    public Guid ProposalId { get; set; }
}
