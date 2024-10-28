using System;
using Domain.Entities;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DataEF.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly AppDbContext _appDbContext;

    public ServiceRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Service> CreateAsync(Service service)
    {
        await _appDbContext.Services.AddAsync(service);
        await _appDbContext.SaveChangesAsync();
        return service;
    }

    public async Task<List<Service>> GetAllFromUserAsync(Guid userId, int perPage, int page)
    {
        List<Service> data;
        IQueryable<Service> query = _appDbContext.Services;
        int skipAmount = page * perPage;
        query = query
            .Where(x => x.ClientId == userId)
            .Skip(skipAmount)
            .Take(perPage);

        data = await query.AsNoTracking().ToListAsync();

        return data;
    }
    public async Task<Service?> GetOneFromUserAsync(Guid userId, Guid serviceId)
    {
        return await _appDbContext.Services
            .Where(x => x.ClientId == userId)
            .Include(x => x.ServiceCategory)
            .FirstOrDefaultAsync(x => x.Id == serviceId);
    }
    public async Task DeleteAsync(Service service)
    {
        _appDbContext.Services.Remove(service);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<Service> UpdateAsync(Service service)
    {
        _appDbContext.Services.Update(service);
        await _appDbContext.SaveChangesAsync();
        return service;
    }
    public async Task<List<Service>> GetClientServicesInProgress(Guid userId, int perPage, int page)
    {
        List<Service> data;
        IQueryable<Service> query = _appDbContext.Services;
        int skipAmount = page * perPage;
        query = query
            .Where(x => x.ClientId == userId)
            .Where(x => x.Status == Domain.Enums.ServiceStatus.PROPOSAL_ACCEPTED)
            .Skip(skipAmount)
            .Take(perPage);

        data = await query.AsNoTracking().ToListAsync();

        return data;
    }
    public async Task<List<Service>> GetAllWaitingProposalAsync(int perPage, int page)
    {
        List<Service> data;
        IQueryable<Service> query = _appDbContext.Services;
        int skipAmount = page * perPage;
        query = query
            .Where(x => x.Status == Domain.Enums.ServiceStatus.WAITING_PROPOSAL)
            .Skip(skipAmount)
            .Take(perPage);

        data = await query.AsNoTracking().ToListAsync();

        return data;
    }
    public async Task<Service?> GetOneById(Guid serviceId)
    {
        return await _appDbContext.Services.FirstOrDefaultAsync(x => x.Id == serviceId);
    }

    public async Task<List<Service>> GetAllInProgressFromProfessionalAsync(Guid professionalId, int perPage, int page)
    {
        List<Service> data;
        IQueryable<Service> query = _appDbContext.Services;
        int skipAmount = page * perPage;
        query = query
            .Where(x => x.Status == Domain.Enums.ServiceStatus.PROPOSAL_ACCEPTED)
            .Where(x => x.ProfessionalId == professionalId)
            .Skip(skipAmount)
            .Take(perPage);

        data = await query.AsNoTracking().ToListAsync();

        return data;
    }
}
