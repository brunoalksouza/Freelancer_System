using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities;

public class Service
{
    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public Guid? ProfessionalId { get; set; }
    public String Title { get; set; }
    public String Message { get; set; }
    public float Price { get; set; }
    public DateTime ServiceDay { get; private set; }
    public DateTime ServiceHour { get; set; }
    public ServiceStatus Status { get; set; }
    public ServiceType ServiceType { get; set; }

    public async Task SetServiceDayAsync(DateTime serviceDay)
    {
        if (ServiceDay < DateTime.Today)
        {
            throw new InvalidServiceDayException("Service day need to be in the future.");
        }
        ServiceDay = serviceDay;
    }
}