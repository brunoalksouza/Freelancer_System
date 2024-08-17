using System.Text;
using IdentityAuth;
using IdentityAuth.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
namespace API.Extensions;

public static class ConfigureIdentityAuthExtension
{
    public static void ConfigureIdentityAuth(this WebApplicationBuilder builder)
    {
        builder.Services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();

        var jwtAppSettingOptions = builder.Configuration.GetSection(nameof(JwtOptions));
        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtOptions:SecurityKey").Value));

        builder.Services.Configure<JwtOptions>(options =>
        {
            options.Issuer = jwtAppSettingOptions[nameof(JwtOptions.Issuer)];
            options.Audience = jwtAppSettingOptions[nameof(JwtOptions.Audience)];
            options.SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
            options.Expiration = int.Parse(jwtAppSettingOptions[nameof(JwtOptions.Expiration)] ?? "0");
        });

        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
        });

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration.GetSection("JwtOptions:Issuer").Value,

            ValidateAudience = true,
            ValidAudience = builder.Configuration.GetSection("JwtOptions:Audience").Value,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = securityKey,

            ClockSkew = TimeSpan.Zero

        };

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = tokenValidationParameters;
        });
    }
}