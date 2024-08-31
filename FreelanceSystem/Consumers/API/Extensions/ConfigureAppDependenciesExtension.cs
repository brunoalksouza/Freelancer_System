using Application.InfraPorts;
using Application.Services;
using Application.ServicesPorts;
using DataEF.Repositories;
using Domain.Ports;
using IdentityAuth;
using IdentityAuth.JWT;

namespace API.Extensions;

public static class ConfigureAppDependenciesExtension
{
    public static void ConfigureDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IAuthUserAdapter, IdentityAuthService>();
        builder.Services.AddTransient<IUserRepository, UserRepository>();
        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddScoped<JwtGenerator>();

    }
}