using LojaMariana.Infraestrutura.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
namespace LojaMariana.WebApp.DependencyInjection;
public static class EntityFrameworkConfig
{
    public static void AddEntityFrameworkConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =
            Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING") ??
            configuration.GetConnectionString("DefaultConnection") ??
            configuration["SQL_CONNECTION_STRING"] ??
            throw new InvalidOperationException("No connection string found. Please configure SQL_CONNECTION_STRING in appsettings.json or as environment variable.");

        services.AddDbContext<lojaMarianaDbContext>(options =>
            options.UseNpgsql(connectionString)
        );
    }
}
