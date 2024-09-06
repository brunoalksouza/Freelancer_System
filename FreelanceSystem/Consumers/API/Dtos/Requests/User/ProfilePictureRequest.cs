using System;

namespace API.Dtos.Requests.User;

public class ProfilePictureRequest
{
    public IFormFile ProfilePicture { get; set; }
}
