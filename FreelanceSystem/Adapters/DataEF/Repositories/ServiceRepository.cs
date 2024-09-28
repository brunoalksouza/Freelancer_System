using System;
using Domain.Entities;
using Domain.Ports;

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
}
