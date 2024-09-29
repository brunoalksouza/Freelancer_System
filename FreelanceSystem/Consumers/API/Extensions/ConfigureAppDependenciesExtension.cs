using API.Services;
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
        builder.Services.AddScoped<SaveProfilePictureService>();
        builder.Services.AddScoped<IServiceCategoryRepository, ServiceCategoryRepository>();
        builder.Services.AddScoped<IServiceCategoryService, ServiceCategoryService>();
        builder.Services.AddScoped<IClientService, ClientService>();
        builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
        builder.Services.AddScoped<IProposalRepository, ProposalRepository>();
    }
}