using System;
using System.Runtime.Serialization;
using Domain.Entities;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<ServiceCategory>> GetAllAsync(int perPage, int page)
    {

        IQueryable<ServiceCategory> query = _appDbContext.ServiceCategories;
        var totalCount = await query.CountAsync();
        int skipAmount = page * perPage;
        query = query
            .OrderByDescending(x => x.Id)
            .Skip(skipAmount)
            .Take(perPage);
        var totalPages = (int)Math.Ceiling((double)totalCount / perPage);
        var currentPage = page + 1;
        var nextPage = currentPage < totalPages ? currentPage + 1 : 1;
        var prevPage = currentPage > 1 ? currentPage - 1 : 1;

        var data = await query.AsNoTracking().ToListAsync();

        return data;
    }
    public async Task<ServiceCategory?> GetOneByIdAsync(Guid id)
    {
        return await _appDbContext.ServiceCategories
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ServiceCategory?> UpdateAsync(ServiceCategory serviceCategory)
    {
        _appDbContext.ServiceCategories.Update(serviceCategory);
        await _appDbContext.SaveChangesAsync();
        return serviceCategory;
    }
    public async Task DeleteAsync(ServiceCategory serviceCategory)
    {
        _appDbContext.ServiceCategories.Remove(serviceCategory);
        await _appDbContext.SaveChangesAsync();
    }
}
