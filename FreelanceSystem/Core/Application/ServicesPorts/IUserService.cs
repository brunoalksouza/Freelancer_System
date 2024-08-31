using System;
using Application.Requests.User;
using Application.Responses.User;

namespace Application.ServicesPorts;

public interface IUserService
{
    public Task<CreatedUserResponse> CreateUserAsync(CreateUserRequest request);
}
