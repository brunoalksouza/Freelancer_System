using Domain.Enums;

namespace Domain.Entities;

public class Review
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public int TotalNumbers { get; set; }
    public String Comment { get; set; }
    public ReviewFrom From { get; set; }
}