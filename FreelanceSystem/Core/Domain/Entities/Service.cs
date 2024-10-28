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
    public float Price { get; private set; }
    public DateTime ServiceDay { get; private set; }
    public DateTime ServiceHour { get; set; }
    public ServiceStatus Status { get; set; }
    public ServiceCategory ServiceCategory { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;

    public void SetServiceDay(DateTime serviceDay)
    {
        if (serviceDay < DateTime.Today)
        {
            throw new InvalidServiceDayException("Service day need to be in the future.");
        }
        ServiceDay = serviceDay;
    }
    public void SetPrice(float price)
    {
        var minimumPrice = 25.0;

        if (price <= minimumPrice)
        {
            throw new LowPriceException("The service price need to be bigger than R$ 25,00");
        }
        Price = price;
    }
}