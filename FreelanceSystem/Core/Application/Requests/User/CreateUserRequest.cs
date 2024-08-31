using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Application.Attributes;
using Domain.Enums;

namespace Application.Requests.User;

public class CreateUserRequest
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; }
    [Required]
    [PasswordValidation]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
    public DateTime BirthDate { get; set; }

    [JsonIgnore]
    public UserRole Roles { get; private set; }

    public void SetRole(UserRole role) => Roles = role;
}