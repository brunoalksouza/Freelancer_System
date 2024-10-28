using System;

namespace Application.Requests.Client;

public class UpdateServiceRequest
{
    public String? Title { get; set; }
    public String? Message { get; set; }
    public float? Price { get; set; }
    public DateTime? ServiceDay { get; set; }
    public DateTime? ServiceHour { get; set; }
    public Guid? ServiceCategory { get; set; }
}
