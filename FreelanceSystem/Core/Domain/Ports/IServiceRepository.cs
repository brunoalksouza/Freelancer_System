using Domain.Entities;

namespace Domain.Ports;

public interface IServiceRepository
{
    public Task<Service> CreateAsync(Service service);
}