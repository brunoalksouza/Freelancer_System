using Application.Requests.Professional;
using Domain.Entities;

namespace Application.ServicesPorts;

public interface IProfessionalService
{
    public Task<List<Service>> GetNewServicesAsync(GetServicesRequest request);

}