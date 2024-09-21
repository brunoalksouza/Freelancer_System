using System;
using Domain.Entities;

namespace Application.Responses.ServiceCategory;

public class CreatedServiceCategoryResponse
{
    public Domain.Entities.ServiceCategory Success { get; set; }

    public List<string> Errors { get; private set; }
    public CreatedServiceCategoryResponse()
    {
        Errors = new List<string>();
    }

    public void AddError(string error) => Errors.Add(error);
    public void SetErrors(List<string> errors) => Errors = errors;
}
