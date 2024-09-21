using System;
using Domain.Entities;

namespace Domain.Ports;

public interface IServiceCategoryRepository
{
    public Task<ServiceCategory> CreateAsync(ServiceCategory serviceCategory);
    public Task<List<ServiceCategory>> GetAllAsync(int perPage, int page);
    public Task<ServiceCategory?> GetOneById(Guid id);
}
