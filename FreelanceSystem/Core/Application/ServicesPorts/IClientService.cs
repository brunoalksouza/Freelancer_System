using Application.Dtos;
using Application.Requests.Client;
using Domain.Entities;

namespace Application.ServicesPorts;

public interface IClientService
{
    public Task<Service> CreateAsync(CreateNewServiceRequest request, string userId);
    public Task<List<Service>> GetAllAsync(string userId, GetServicesRequest request);
    public Task<Service?> GetOneAsync(string userId, Guid serviceId);
    public Task DeleteAsync(string userId, Guid serviceId);
    public Task<Service> UpdateAsync(string userId, Guid serviceId, UpdateServiceRequest request);
    public Task<List<UserDto>> GetAllProfessionalsAsync(GetAllProfessionalsRequest request);
    public Task<Proposal> SendProposalToProfessionalAsync(SendProposalToProfessionalRequest request, string userId, Guid professionalId);
    public Task<List<Service>> GetClientServicesInProgressAsync(string userId, GetClientServicesInProgressRequest request);
}