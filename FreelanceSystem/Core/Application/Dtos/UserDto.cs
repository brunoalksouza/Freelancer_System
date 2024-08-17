namespace Application.Dtos;

public class UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public UserDto()
    {
        
    }
    public UserDto(Domain.Entities.User created)
    {
        Id = created.Id;
        Email = created.Email;
        Name = created.Name;
        Role = created.Role.ToString();
    }
}