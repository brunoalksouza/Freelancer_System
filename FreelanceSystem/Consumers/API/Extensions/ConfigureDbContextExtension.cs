namespace API.Extensions;

public static class ConfigureDbContextExtension
{
    public static void ConfigureDbContext(this WebApplicationBuilder builder)
    {
        var connectionString = Environment.GetEnvironmentVariable("MyConnectionString");
        if (!string.IsNullOrEmpty(connectionString))
        {
            // Adiciona ou sobrescreve a configuração com a variável de ambiente
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
            {
                { "ConnectionStrings:DefaultConnection", connectionString }
            });
        }
    }
}