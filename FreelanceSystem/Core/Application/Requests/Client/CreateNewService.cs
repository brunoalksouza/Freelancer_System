using System.ComponentModel.DataAnnotations;

namespace Application.Requests.Client;

public class CreateNewServiceRequest
{
    [Required]
    public String Title { get; set; }
    [Required]
    public String Message { get; set; }
    [Required]
    public float Price { get; set; }
    [Required]
    public DateTime ServiceDay { get; set; }
    [Required]
    public DateTime ServiceHour { get; set; }
    [Required]
    public Guid ServiceCategory { get; set; }
}
