using Application.Requests.Client;
using Application.Requests.Professional;
using Domain.Entities;

namespace Application.ServicesPorts;

public interface IProfessionalService
{
    public Task<List<Service>> GetNewServicesAsync(Application.Requests.Professional.GetServicesRequest request);
    public Task<Proposal> SendProfessionalProposalAsync(SendProposalToServiceRequest request, Guid serviceId, string userId);
    public Task<List<Proposal>> GetAllSendedProposalAsync(GetProfessionalProposalsRequest request, string userId);
    public Task CancelProposalAsync(Guid proposalId, string userId);
    public Task<List<Service>> GetAllServicesInProgressAsync(GetAllServicesInProgressRequest request, string userId);
    public Task<List<Proposal>> GetAllClienteProposalsSendedAsync(GetAllServicesInProgressRequest request, string userId);
}