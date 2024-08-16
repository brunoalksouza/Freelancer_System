using Domain.Enums;

namespace Domain.Entities;

public class Service
{
    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public Guid? ProfessionalId { get; set; }
    public String Title { get; set; }
    public String Message { get; set; }
    public float Price { get; set; }
    public DateTime ServiceDay { get; set; }
    public DateTime ServiceHour { get; set; }
    public ServiceStatus Status { get; set; }
    public ServiceType ServiceType { get; set; }
}