using System;
using Application.Dtos;

namespace Application.Responses.User;

public class UpdatedUserResponse
{
    public UserDto Success { get; set; }

    public List<string> Errors { get; private set; }
    public UpdatedUserResponse()
    {
        Errors = new List<string>();
    }

    public void AddError(string error) => Errors.Add(error);
    public void SetErrors(List<string> errors) => Errors = errors;
}
