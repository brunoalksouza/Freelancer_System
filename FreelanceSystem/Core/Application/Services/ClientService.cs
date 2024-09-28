using System;
using Application.InfraPorts;
using Application.Requests.Client;
using Application.ServicesPorts;
using Domain.Entities;
using Domain.Ports;

namespace Application.Services;

public class ClientService : IClientService
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IUserRepository _userRepository;
    private readonly IAuthUserAdapter _authUserAdapter;
    private readonly IServiceCategoryRepository _serviceCategoryRepository;

    public ClientService(IServiceRepository serviceRepository, IUserRepository userRepository, IAuthUserAdapter authUserAdapter, IServiceCategoryRepository serviceCategoryRepository)
    {
        _serviceRepository = serviceRepository;
        _userRepository = userRepository;
        _authUserAdapter = authUserAdapter;
        _serviceCategoryRepository = serviceCategoryRepository;
    }

    public async Task<Service> CreateAsync(CreateNewServiceRequest request, string userId)
    {
        var authUser = await _authUserAdapter.GetOneByIdAsync(new Guid(userId));
        var user = await _userRepository.GetOneByEmailAsync(authUser.Email);
        var serviceCategory = await _serviceCategoryRepository.GetOneByIdAsync(request.ServiceCategory);
        if (serviceCategory == null)
        {
            throw new Exception("Service category not found.");
        }

        var service = new Service
        {
            ClientId = user.Id,
            Message = request.Message,
            Title = request.Title,
            ServiceCategory = serviceCategory
        };
        service.SetPrice(request.Price);
        service.SetServiceDay(request.ServiceDay);
        var created = await _serviceRepository.CreateAsync(service);

        return created;

    }
}
