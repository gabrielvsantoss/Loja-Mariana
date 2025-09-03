using Microsoft.EntityFrameworkCore;
using LojaMariana.WebApp.ActionFilters;
using LojaMariana.WebApp.DependencyInjection;
using LojaMariana.WebApp.Orm;
using LojaMariana.Dominio.ModuloCompra;
using LojaMariana.InfraestruturaEmOrm.ModuloCompra;
using LojaMariana.Dominio.ModuloCliente;
using LojaMariana.InfraestruturaEmOrm.ModuloCliente;
using LojaMariana.Dominio.ModuloProduto;
using LojaMariana.InfraestruturaEmOrm.ModuloProduto;
using LojaMariana.Aplicacao.ModuloCliente;
using LojaMariana.Dominio.Compartilhado;
using LojaMariana.Infraestrutura.Orm.Compartilhado;
using LojaMariana.Aplicacao.ModuloProduto;
namespace Duobingo.WebApp;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews(options =>
        {
            options.Filters.Add<ValidarModeloAttribute>();
        });

        builder.Services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<lojaMarianaDbContext>());

        builder.Services.AddScoped<IRepositorioCliente, RepositorioClienteEmOrm>();
        builder.Services.AddScoped<IRepositorioProduto, RepositorioProdutoEmOrm>();
        builder.Services.AddScoped<IRepositorioCompra, RepositorioCompraEmOrm>();
        builder.Services.AddScoped<ClienteAppService>();
        builder.Services.AddScoped<ProdutoAppService>();

        builder.Services.AddEntityFrameworkConfig(builder.Configuration);

        builder.Services.AddSerilogConfig(builder.Logging);
        var app = builder.Build();

        //Migra??es do banco


        app.UseExceptionHandler("/Erro");


        app.ApllyMigrations();
        app.UseAntiforgery();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.MapDefaultControllerRoute();
        app.Run();

    }
}