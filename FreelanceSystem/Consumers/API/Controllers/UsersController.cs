using System.Security.Claims;
using Application.InfraPorts;
using Application.Requests.User;
using Application.ServicesPorts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/v1/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuthUserAdapter _authUserAdapter;
    public UsersController(IUserService userService, IAuthUserAdapter authUserAdapter)
    {
        _userService = userService;
        _authUserAdapter = authUserAdapter;
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateBasicInfoAsync([FromBody] UpdateUserBasicInfoRequest request)
    {
        var userEmail = User.FindFirstValue(ClaimTypes.Email);
        System.Console.WriteLine(userEmail);
        var update = await _userService.UpdateUserBasicInfoAsync(request, userEmail);

        return Ok(update);
    }

}

