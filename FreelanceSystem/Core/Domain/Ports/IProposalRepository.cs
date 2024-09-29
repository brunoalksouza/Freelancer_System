using Domain.Entities;
using Domain.Enums;

namespace Domain.Ports;

public interface IProposalRepository
{
    public Task<Proposal> CreateAsync(Proposal proposal);   
    public Task<List<Proposal>> GetAllFromServiceAsync(Guid serviceId, int perPage, int page, ProposalType proposalType);
}