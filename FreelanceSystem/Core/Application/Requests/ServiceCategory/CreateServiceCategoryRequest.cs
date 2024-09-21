using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Requests.ServiceCategory;

public class CreateServiceCategoryRequest
{
    [Required(AllowEmptyStrings = false)]
    [MinLength(3)]
    public string Title { get; set; }
    [Required(AllowEmptyStrings = false)]
    [MinLength(3)]
    public string Description { get; set; }
}
