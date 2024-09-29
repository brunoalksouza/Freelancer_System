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
        if (data == null)
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
    [HttpPut("services/{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateServiceRequest request)
    {
        var user = HttpContext.User;
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        var updated = await _clientService.UpdateAsync(userId, id, request);

        return Ok(updated);
    }
    [HttpGet("professionals")]
    public async Task<IActionResult> GetAllProfessionalsAsync([FromQuery] GetAllProfessionalsRequest request)
    {
        var data = await _clientService.GetAllProfessionalsAsync(request);
        return Ok(data);
    }
    [HttpPost("professionals/{id}")]
    public async Task<IActionResult> SendProfessionalProposalAsync([FromBody] SendProposalToProfessionalRequest request, Guid id)
    {
        var user = HttpContext.User;
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        var created = await _clientService.SendProposalToProfessionalAsync(request, userId, id);

        return Ok(created);
    }
    [HttpGet("services/in-progress")]
    public async Task<IActionResult> GetAllServicesInProgressAsync([FromQuery] GetClientServicesInProgressRequest request)
    {
        var user = HttpContext.User;
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        var data = await _clientService.GetClientServicesInProgressAsync(userId, request);

        return Ok(data);
    }
    [HttpPatch("services/{id}/finish")]
    public async Task<IActionResult> FinishServiceAsync(Guid id)
    {
        var user = HttpContext.User;
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        var updated = await _clientService.FinishServiceAsync(new Guid(userId), id);
        return Ok(updated);
    }
    [HttpGet("services/{id}/proposals")]
    public async Task<IActionResult> GetServiceProposals(Guid id, [FromQuery] GetServiceProposalRequest request)
    {
        var user = HttpContext.User;
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        var data = await _clientService.GetServiceProfessionalsProposalsAsync(new Guid(userId), id, request);
        return Ok(data);
    }

}