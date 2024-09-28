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
            .FirstOrDefaultAsync(x => x.Id == serviceId);
    }
}
