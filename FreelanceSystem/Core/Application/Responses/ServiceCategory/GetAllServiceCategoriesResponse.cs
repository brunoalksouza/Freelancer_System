using System;
using Domain.Entities;

namespace Application.Responses.ServiceCategory;

public class GetAllServiceCategoriesResponse
{
    public List<Domain.Entities.ServiceCategory> Success { get; set; }
    public int Page { get; set; }
    public int PerPage { get; set; }
}
