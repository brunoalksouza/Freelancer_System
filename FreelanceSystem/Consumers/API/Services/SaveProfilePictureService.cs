using System;

namespace API.Services;

public class SaveProfilePictureService
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    public SaveProfilePictureService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    public async Task<string> SaveAsync(IFormFile file)
    {
        string? filePath = null;
        var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "users-profiles/pictures");

        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
            await file.CopyToAsync(stream);

        filePath = Path.Combine("uploads/users-profiles/pictures", uniqueFileName);
        return filePath;
    }

}
