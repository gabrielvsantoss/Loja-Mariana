using LojaMariana.Infraestrutura.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
namespace LojaMariana.WebApp.Orm;
public static class DataBaseOperations
{

    public static void ApllyMigrations(this IHost app)
    {
        var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<lojaMarianaDbContext>();

        dbContext.Database.Migrate();
    }
}
