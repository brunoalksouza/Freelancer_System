using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using API.Dtos.Requests.User;
using API.Services;
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
    private readonly SaveProfilePictureService _saveProfilePictureService;
    public UsersController(IUserService userService, IAuthUserAdapter authUserAdapter, SaveProfilePictureService saveProfilePictureService)
    {
        _userService = userService;
        _authUserAdapter = authUserAdapter;
        _saveProfilePictureService = saveProfilePictureService;
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateBasicInfoAsync([FromBody] UpdateUserBasicInfoRequest request)
    {
        var userEmail = User.FindFirstValue(ClaimTypes.Email);
        var update = await _userService.UpdateUserBasicInfoAsync(request, userEmail);

        return Ok(update);
    }

    [HttpPut("profile-picture")]
    [Authorize]
    public async Task<IActionResult> UpdateProfilePicture([FromForm] ProfilePictureRequest request)
    {
        var userEmail = User.FindFirstValue(ClaimTypes.Email);
        var saved = await _saveProfilePictureService.SaveAsync(request.ProfilePicture);
        var updaterequest = new UpdateUserProfilePictureRequest { Path = saved };
        await _userService.UpdateUserProfilePictureAsync(updaterequest, userEmail);
        return NoContent();
    }
}

