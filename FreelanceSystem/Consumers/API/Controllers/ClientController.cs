using System.Security.Claims;
using Application.Requests.Client;
using Application.ServicesPorts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Route("api/v1/clients")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpPost("services")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateNewServiceRequest request)
    {
        var user = HttpContext.User;
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        var created = await _clientService.CreateAsync(request, userId);

        var uri = "api/v1/clients/services/" + created.Id;
        return Created(uri, created);
    }
    [HttpGet("services")]
    public async Task<IActionResult> GetAllAsync([FromQuery] GetServicesRequest request)
    {
        var user = HttpContext.User;
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        var data = await _clientService.GetAllAsync(userId, request);

        return Ok(data);
    }
    [HttpGet("services/{id}")]
    public async Task<IActionResult> GetOneByIdAsync(Guid id)
    {
        var user = HttpContext.User;
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        var data = await _clientService.GetOneAsync(userId, id);
        if(data == null)
            return NotFound();

        return Ok(data);
    }
    [HttpDelete("services/{id}")]
    public async Task<IActionResult> DeleteOneByIdAsync(Guid id)
    {
        var user = HttpContext.User;
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        await _clientService.DeleteAsync(userId, id);

        return NoContent();
    }

}