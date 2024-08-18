namespace Domain.Enums;

public class ServiceType
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
}