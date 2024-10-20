using System;
using System.Security.Claims;
using Application.Requests.Client;
using Application.Requests.Professional;
using Application.ServicesPorts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Route("api/v1/professional")]
[ApiController]
public class ProfessionalController : ControllerBase
{
    private readonly IProfessionalService _professionalService;

    public ProfessionalController(IProfessionalService professionalService)
    {
        _professionalService = professionalService;
    }

    [HttpGet("services")]
    public async Task<IActionResult> GetServicesAsync([FromQuery] Application.Requests.Professional.GetServicesRequest request)
    {
        var data = await _professionalService.GetNewServicesAsync(request);
        return Ok(data);
    }

    [HttpPost("services/{id}/proposal")]
    public async Task<IActionResult> SendProfessionalProposalAsync([FromBody] SendProposalToServiceRequest request, Guid id)
    {
        var user = HttpContext.User;
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        var data = await _professionalService.SendProfessionalProposalAsync(request, id, userId);

        return Ok(data);
    }
    [HttpGet("proposals")]
    public async Task<IActionResult> GetAllSendedProposalAsync([FromQuery] GetProfessionalProposalsRequest request)
    {
        var user = HttpContext.User;
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        var data = await _professionalService.GetAllSendedProposalAsync(request, userId);

        return Ok(data);
    }

    [HttpDelete("proposal/{proposalId}")]
    public async Task<IActionResult> GetAllSendedProposalAsync(Guid proposalId)
    {
        var user = HttpContext.User;
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        await _professionalService.CancelProposalAsync(proposalId, userId);

        return Ok(new { success = "Proposal recused successfully!" });
    }
}
