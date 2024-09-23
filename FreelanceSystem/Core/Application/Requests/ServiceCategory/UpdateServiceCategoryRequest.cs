using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Requests.ServiceCategory;

public class UpdateServiceCategoryRequest
{
    [MinLength(3)]
    public string Title { get; set; }
    [MinLength(3)]
    public string Description { get; set; }
}
