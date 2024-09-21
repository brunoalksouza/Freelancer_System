using System;
using System.ComponentModel.DataAnnotations;
using Application.Requests.ServiceCategory;
using Application.Responses.ServiceCategory;
using Application.ServicesPorts;
using Domain.Entities;
using Domain.Ports;

namespace Application.Services;

public class ServiceCategoryService : IServiceCategoryService
{
    private readonly IServiceCategoryRepository _serviceCategoryRepository;

    public ServiceCategoryService(IServiceCategoryRepository serviceCategoryRepository)
    {
        _serviceCategoryRepository = serviceCategoryRepository;
    }

    public async Task<CreatedServiceCategoryResponse> CreateAsync(CreateServiceCategoryRequest request)
    {
        var response = new CreatedServiceCategoryResponse();
        var context = new ValidationContext(request, serviceProvider: null, items: null);
        var results = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(request, context, results, true);

        if (!isValid)
        {
            foreach (var error in results)
                response.AddError(error.ErrorMessage);
            return response;
        }
        var created = await _serviceCategoryRepository.CreateAsync(new Domain.Entities.ServiceCategory{
            Description = request.Description,
            Title = request.Title
        });

        response.Success = created;
        return response;
    }

    public async Task<GetAllServiceCategoriesResponse> GetAllAsync(GetServiceCategoriesRequest request){
        var data = await _serviceCategoryRepository.GetAllAsync(request.PerPage, request.Page);
        var response = new GetAllServiceCategoriesResponse
        {
            Page = request.Page,
            PerPage = request.PerPage,
            Success = data,
        };
        return response;
    }

    public async Task<ServiceCategory?> GetOneByIdAsync(Guid id){
        return await _serviceCategoryRepository.GetOneById(id);
    }

}
