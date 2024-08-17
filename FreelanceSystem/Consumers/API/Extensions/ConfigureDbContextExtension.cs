using DataEF;
using IdentityAuth;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ConfigureDbContextExtension
{
    public static void ConfigureDbContext(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("SqlServer");

        builder.Services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        builder.Services.AddDbContext<AuthDbContext>(opt =>
            opt.UseSqlServer(connectionString)
        );
    }
}