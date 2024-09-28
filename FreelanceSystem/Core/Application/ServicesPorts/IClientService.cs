using Application.Requests.Client;
using Domain.Entities;

namespace Application.ServicesPorts;

public interface IClientService
{
    public Task<Service> CreateAsync(CreateNewServiceRequest request, string userId);
}