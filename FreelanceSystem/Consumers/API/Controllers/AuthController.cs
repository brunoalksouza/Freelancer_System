using Application.InfraPorts;
using Application.Requests.Auth;
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
    private readonly IAuthUserAdapter _authUserAdapter;
    public AuthController(IUserService userService, IAuthUserAdapter authUserAdapter)
    {
        _userService = userService;
        _authUserAdapter = authUserAdapter;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginUserRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var resultado = await _authUserAdapter.AuthenticateAsync(request);
        if (resultado.Errors.Count <= 0)
            return Ok(resultado);

        return Unauthorized(resultado);
    }

    [HttpPost("register/client")]
    public async Task<IActionResult> CreateClientAsync(CreateUserRequest request)
    {
        request.SetRole(UserRole.CLIENT);
        var created = await _userService.CreateUserAsync(request);
        var uri = "api/v1/users/" + created.Success.Id;
        return Created(uri, created);
    }
    [HttpPost("register/professional")]
    public async Task<IActionResult> CreateProfessionalAsync(CreateUserRequest request)
    {
        request.SetRole(UserRole.PROFESSIONAL);
        var created = await _userService.CreateUserAsync(request);
        var uri = "api/v1/users/" + created.Success.Id;
        return Created(uri, created);
    }

}

