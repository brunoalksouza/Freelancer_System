using DataEF;
using IdentityAuth;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ConfigureDbContextExtension
{
    public static void ConfigureDbContext(this WebApplicationBuilder builder)
    {
        var connectionString = Environment.GetEnvironmentVariable("VPSConnectionString");
        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("VPSConnectionString enviroment variable is not configured");

        builder.Services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        builder.Services.AddDbContext<AuthDbContext>(opt =>
            opt.UseSqlServer(connectionString)
        );
    }
}