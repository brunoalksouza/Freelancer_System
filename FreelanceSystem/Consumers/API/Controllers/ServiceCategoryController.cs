using Application.Requests.ServiceCategory;
using Application.ServicesPorts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Route("api/v1/service-categories")]
[ApiController]
public class ServiceCategoryController : ControllerBase
{
    private readonly IServiceCategoryService iServiceCategoryService;

    public ServiceCategoryController(IServiceCategoryService iServiceCategoryService)
    {
        this.iServiceCategoryService = iServiceCategoryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateServiceCategoryRequest request){
        var created = await iServiceCategoryService.CreateAsync(request);
        return Created("",created);
    }
}

