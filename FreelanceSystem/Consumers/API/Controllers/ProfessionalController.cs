using System;
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
    public async Task<IActionResult> GetServicesAsync([FromQuery] GetServicesRequest request)
    {
        var data = await _professionalService.GetNewServicesAsync(request);
        return Ok(data);
    }
}
