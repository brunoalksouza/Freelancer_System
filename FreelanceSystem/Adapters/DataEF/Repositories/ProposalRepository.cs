using System;
using Domain.Entities;
using Domain.Ports;

namespace DataEF.Repositories;

public class ProposalRepository : IProposalRepository
{
    private readonly AppDbContext _appDbContext;

    public ProposalRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<Proposal> CreateAsync(Proposal proposal)
    {
        await _appDbContext.Proposals.AddAsync(proposal);
        await _appDbContext.SaveChangesAsync();
        return proposal;
    }
}
