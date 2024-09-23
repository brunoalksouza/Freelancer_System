using System;
using Application.Requests.ServiceCategory;
using Application.Responses.ServiceCategory;
using Domain.Entities;

namespace Application.ServicesPorts;

public interface IServiceCategoryService
{
    public Task<CreatedServiceCategoryResponse> CreateAsync(CreateServiceCategoryRequest request);
    public Task<GetAllServiceCategoriesResponse> GetAllAsync(GetServiceCategoriesRequest request);
    public Task<ServiceCategory?> GetOneByIdAsync(Guid id);
    public Task<ServiceCategory?> UpdateAsync(UpdateServiceCategoryRequest request, ServiceCategory serviceCategory);
}
