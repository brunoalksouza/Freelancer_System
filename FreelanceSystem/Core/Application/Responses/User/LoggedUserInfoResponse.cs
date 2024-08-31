using System;
using Domain.Entities;

namespace Application.Responses.User;

public class LoggedUserInfoResponse
{
    public Guid Id { get; set; }
    public String Name { get; set; }
    public String? CPF { get; set; }
    public String? Phone { get; set; }
    public String Email { get; set; }
    public String? ProfilePicture { get; set; }
    public DateTime BirthDate { get; set; }
    public bool ProfileIsCompleted { get; set; }
    public string Role { get; set; }

    public LoggedUserInfoResponse() { }
    public LoggedUserInfoResponse(Domain.Entities.User user)
    {
        Id = user.Id;
        Name = user.Name;
        CPF = user.CPF;
        Phone = user.Phone;
        Email = user.Email;
        ProfilePicture = user.ProfilePicture;
        BirthDate = user.BirthDate;
        ProfileIsCompleted = user.ProfileIsCompleted;
        Role = user.Role.ToString();
    }
}
