using Application.Requests.User;
using Application.ServicesPorts;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/v1")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register/client")]
    public async Task<IActionResult> CreateUserAsync(CreateUserRequest request)
    {
        request.SetRole(UserRole.CLIENT);
        var created = await _userService.CreateUserAsync(request);
        var uri = "api/v1/users/" + created.Success.Id;
        return Created(uri, created);
    }

}

