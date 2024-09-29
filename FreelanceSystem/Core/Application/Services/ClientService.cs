using System;
using System.Security.Cryptography.X509Certificates;
using Application.Dtos;
using Application.Exceptions;
using Application.InfraPorts;
using Application.Requests.Client;
using Application.ServicesPorts;
using Domain.Entities;
using Domain.Enums;
using Domain.Ports;

namespace Application.Services;

public class ClientService : IClientService
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IUserRepository _userRepository;
    private readonly IAuthUserAdapter _authUserAdapter;
    private readonly IServiceCategoryRepository _serviceCategoryRepository;
    private readonly IProposalRepository _proposalRepository;

    public ClientService(IServiceRepository serviceRepository, IUserRepository userRepository, IAuthUserAdapter authUserAdapter, IServiceCategoryRepository serviceCategoryRepository, IProposalRepository proposalRepository)
    {
        _serviceRepository = serviceRepository;
        _userRepository = userRepository;
        _authUserAdapter = authUserAdapter;
        _serviceCategoryRepository = serviceCategoryRepository;
        _proposalRepository = proposalRepository;
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
    public async Task<List<Service>> GetAllAsync(string userId, GetServicesRequest request)
    {
        var authUser = await _authUserAdapter.GetOneByIdAsync(new Guid(userId));
        var user = await _userRepository.GetOneByEmailAsync(authUser.Email);

        var data = await _serviceRepository.GetAllFromUserAsync(user.Id, request.PerPage, request.Page);
        return data;
    }
    public async Task<Service?> GetOneAsync(string userId, Guid serviceId)
    {
        var authUser = await _authUserAdapter.GetOneByIdAsync(new Guid(userId));
        var user = await _userRepository.GetOneByEmailAsync(authUser.Email);
        var service = await _serviceRepository.GetOneFromUserAsync(user.Id, serviceId);
        return service;
    }
    public async Task DeleteAsync(string userId, Guid serviceId)
    {
        var authUser = await _authUserAdapter.GetOneByIdAsync(new Guid(userId));
        var user = await _userRepository.GetOneByEmailAsync(authUser.Email);
        var service = await _serviceRepository.GetOneFromUserAsync(user.Id, serviceId);

        if (service == null)
            throw new EntityNotFoundException("Service not founded");

        await _serviceRepository.DeleteAsync(service);
    }
    public async Task<Service> UpdateAsync(string userId, Guid serviceId, UpdateServiceRequest request)
    {
        var authUser = await _authUserAdapter.GetOneByIdAsync(new Guid(userId));
        var user = await _userRepository.GetOneByEmailAsync(authUser.Email);
        var service = await _serviceRepository.GetOneFromUserAsync(user.Id, serviceId);

        if (service == null)
            throw new EntityNotFoundException("Service not founded");

        ServiceCategory serviceCategory = service.ServiceCategory;
        if (request.ServiceCategory != null)
        {
            await _serviceCategoryRepository.GetOneByIdAsync(new Guid(request.ServiceCategory.ToString()));
            if (serviceCategory == null)
            {
                throw new Exception("Service category not found.");
            }
        }


        service.Message = request.Message != null ? request.Message : service.Message;
        service.Title = request.Title != null ? request.Title : service.Title;
        service.ServiceCategory = serviceCategory;

        if (request.Price != null)
        {
            var preco = (float)request.Price;
            service.SetPrice(preco);
        }
        if (request.ServiceDay != null)
        {
            var day = (DateTime)request.ServiceDay;
            service.SetServiceDay(day);
        }
        var updated = await _serviceRepository.UpdateAsync(service);
        return updated;
    }
    public async Task<List<UserDto>> GetAllProfessionalsAsync(GetAllProfessionalsRequest request)
    {
        var data = await _userRepository.GetAllProfessionalsAsync(request.PerPage, request.Page);
        var final = data.Select(x => new UserDto(x)).ToList();
        return final;
    }
    public async Task<Proposal> SendProposalToProfessionalAsync(SendProposalToProfessionalRequest request, string userId, Guid professionalId)
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
            ProfessionalId = professionalId,
            ClientId = user.Id,
            Message = request.Message,
            Title = request.Title,
            ServiceCategory = serviceCategory
        };
        service.SetPrice(request.Price);
        service.SetServiceDay(request.ServiceDay);

        var serviceCreated = await _serviceRepository.CreateAsync(service);

        var proposal = new Proposal(serviceCreated.Id, request.Comment, request.Price, ProposalType.CLIENT_PROPOSAL, professionalId, user.Id);
        _proposalRepository.CreateAsync(proposal);

        return proposal;
    }


}
