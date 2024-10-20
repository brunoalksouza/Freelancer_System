using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Requests.Client;

public class SendProposalToServiceRequest
{
    [Required]
    public String Comment { get; set; }
    [Required]
    public float Price { get; set; }
}
