using Application.InfraPorts;
using Domain.Ports;
using IdentityAuth;
using IdentityAuth.JWT;

namespace API.Extensions;

public static class ConfigureAppDependenciesExtension
{
    public static void ConfigureDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IAuthUserAdapter, IdentityAuthService>();
        builder.Services.AddScoped<JwtGenerator>();
    }
}