using System;
using Domain.Entities;
using Domain.Enums;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<Proposal>> GetAllFromServiceAsync(Guid serviceId, int perPage, int page, ProposalType proposalType)
    {
        IQueryable<Proposal> query = _appDbContext.Proposals;
        var totalCount = await query.CountAsync();
        int skipAmount = page * perPage;
        query = query
            .OrderByDescending(x => x.Id)
            .Where(x => x.ServiceId == serviceId)
            .Where(x => x.Type == proposalType)
            .Skip(skipAmount)
            .Take(perPage);

        var data = await query.AsNoTracking().ToListAsync();

        return data;
    }
}
