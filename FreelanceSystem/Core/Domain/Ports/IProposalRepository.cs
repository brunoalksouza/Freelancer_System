using Domain.Entities;

namespace Domain.Ports;

public interface IProposalRepository
{
    public Task<Proposal> CreateAsync(Proposal proposal);   
}