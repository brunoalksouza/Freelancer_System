using DataEF;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ConfigureDbContextExtension
{
    public static void ConfigureDbContext(this WebApplicationBuilder builder)
    {
        var connectionString = Environment.GetEnvironmentVariable("VPSConnectionString");
    
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string is not configured.");
        }

        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
        {
            { "ConnectionStrings:DefaultConnection", connectionString }
        });

        builder.Services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
    }
}