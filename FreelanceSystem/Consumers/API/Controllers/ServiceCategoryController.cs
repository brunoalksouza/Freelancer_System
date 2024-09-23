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
    public async Task<IActionResult> CreateAsync([FromBody] CreateServiceCategoryRequest request)
    {
        var created = await iServiceCategoryService.CreateAsync(request);
        return Created("", created);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] GetServiceCategoriesRequest request)
    {
        var data = await iServiceCategoryService.GetAllAsync(request);
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOneAsync(Guid id)
    {
        var data = await iServiceCategoryService.GetOneByIdAsync(id);
        if (data == null)
            return NoContent();
        return Ok(data);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateServiceCategoryRequest request)
    {
        var data = await iServiceCategoryService.GetOneByIdAsync(id);
        if (data == null)
            return NotFound();
       var updated = await iServiceCategoryService.UpdateAsync(request, data);
        return Ok(updated);
    }
}

