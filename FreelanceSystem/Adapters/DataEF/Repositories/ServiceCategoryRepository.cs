using System;
using Domain.Entities;
using Domain.Ports;

namespace DataEF.Repositories;

public class ServiceCategoryRepository : IServiceCategoryRepository
{
    private readonly AppDbContext _appDbContext;

    public ServiceCategoryRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<ServiceCategory> CreateAsync(ServiceCategory serviceCategory)
    {
        await _appDbContext.ServiceCategories.AddAsync(serviceCategory);
        await _appDbContext.SaveChangesAsync();
        return serviceCategory;
    }
}
