using System;
using Application.Requests.Professional;
using Application.ServicesPorts;
using Domain.Entities;
using Domain.Ports;

namespace Application.Services;

public class ProfessionalService : IProfessionalService
{
    private readonly IServiceRepository _serviceRepository;

    public ProfessionalService(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<List<Service>> GetNewServicesAsync(GetServicesRequest request)
    {
        var data = await _serviceRepository.GetAllWaitingProposalAsync(request.PerPage, request.Page);
        return data;
    }
}
