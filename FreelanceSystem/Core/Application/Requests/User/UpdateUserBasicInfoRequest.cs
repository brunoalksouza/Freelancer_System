using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Requests.User;

public class UpdateUserBasicInfoRequest
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public string? CPF { get; set; }
}
