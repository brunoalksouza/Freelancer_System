using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities;

public class Review
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid UserFromId { get; set; }
    public int TotalNumbers { get; private set; }
    public String Comment { get; set; }
    public ReviewFrom From { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public async Task SetTotalNumbersAsync(int totalNumbers)
    {
        if (totalNumbers < 1)
            throw new InvalidReviewException("The total numbers must be greater than 0");
        if(totalNumbers > 5)
            throw new InvalidReviewException("The total numbers must be less than 5");
        
        TotalNumbers = totalNumbers;
    }
}