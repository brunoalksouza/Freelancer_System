using System;
using Application.Requests.ServiceCategory;
using Application.Responses.ServiceCategory;

namespace Application.ServicesPorts;

public interface IServiceCategoryService
{
    public Task<CreatedServiceCategoryResponse> CreateAsync(CreateServiceCategoryRequest request);
    public Task<GetAllServiceCategoriesResponse> GetAllAsync(GetServiceCategoriesRequest request);

}
