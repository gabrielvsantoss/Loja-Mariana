using LojaMariana.Dominio.ModuloAutenticacao;
using LojaMariana.Infraestrutura.Orm.Compartilhado;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace LojaMariana.WebApp.DependencyInjection;

public static  class  IdentifyConfig
{
    public static void AddIndentyProviderConfig(this IServiceCollection services)
    {
        services.AddIdentity<Usuario, Cargo>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.Password.RequireDigit = true;
        })
        .AddEntityFrameworkStores<lojaMarianaDbContext>()
        .AddDefaultTokenProviders();
            
    }
     
    public static void AddCookieAuthenticationConfig(this IServiceCollection services)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.Name = "AspNetCore.Cookies.LojaMariana";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
                options.SlidingExpiration = true;
            });

        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/autenticacao/login";
            options.AccessDeniedPath = "/";
        });
    }
}
