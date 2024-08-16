using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("/")]
public class ExampleController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Get()
    {
        return Ok("Example API");
    }
}