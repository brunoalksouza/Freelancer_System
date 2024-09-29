using Domain.Entities;
using Domain.Enums;

namespace Domain.Ports;

public interface IProposalRepository
{
    public Task<Proposal> CreateAsync(Proposal proposal);   
    public Task<Proposal> UpdateAsync(Proposal proposal);   
    public Task<Proposal?> GetOneFromClientAsync(Guid userId, Guid proposalId, Guid serviceId);
    public Task<List<Proposal>> GetAllFromServiceAsync(Guid serviceId, int perPage, int page, ProposalType proposalType);
}