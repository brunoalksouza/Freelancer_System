using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("/")]
public class ExampleController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public ActionResult<string> Get()
    {
        return Ok("Example API");
    }
}