using System;
using Domain.Entities;

namespace Domain.Ports;

public interface IServiceCategoryRepository
{
    public Task<ServiceCategory> CreateAsync(ServiceCategory serviceCategory);
    public Task<List<ServiceCategory>> GetAllAsync(int perPage, int page);
    public Task<ServiceCategory?> GetOneByIdAsync(Guid id);
    public Task<ServiceCategory?> UpdateAsync(ServiceCategory serviceCategory);
    public Task DeleteAsync(ServiceCategory serviceCategory);
}
