using Domain.Entities;

namespace Domain.Ports;

public interface IServiceRepository
{
    public Task<Service> CreateAsync(Service service);
    public Task<List<Service>> GetAllWaitingProposalAsync(int perPage, int page);
    public Task<List<Service>> GetAllFromUserAsync(Guid userId, int perPage, int page);
    public Task<Service?> GetOneFromUserAsync(Guid userId, Guid serviceId);
    public Task DeleteAsync(Service service);
    public Task<Service> UpdateAsync(Service service);
    public Task<List<Service>> GetClientServicesInProgress(Guid userId, int perPage, int page);
}