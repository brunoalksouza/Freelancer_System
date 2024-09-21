using System;
using Domain.Entities;

namespace Domain.Ports;

public interface IServiceCategoryRepository
{
    public Task<ServiceCategory> CreateAsync(ServiceCategory serviceCategory);
}
