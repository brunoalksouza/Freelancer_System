using Application.Dtos;
using Application.Requests.Auth;
using Application.Responses.Auth;

namespace Application.InfraPorts;

public interface IAuthUserAdapter
{
    public Task<LoggedUserResponse> AuthenticateAsync(LoginUserRequest request);
    public Task<RegisteredUserResponse> RegisterAsync(RegisterUserRequest register);
    public Task UpdateAuthUserAsync(Domain.Entities.User user, UpdateUserRequest request);
    public Task DeleteAsync(Domain.Entities.User user);
    public Task<UserDto?> GetOneByIdAsync(Guid id);
}