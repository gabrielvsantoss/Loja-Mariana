using FluentResults;
using LojaMariana.Dominio.ModuloAutenticacao;
using Microsoft.AspNetCore.Identity;

namespace LojaMariana.Aplicacao.ModuloAutenticacao;
public class AutenticacaoService
{
    public UserManager<Usuario> UserManager { get; }
    public SignInManager<Usuario> SignInManager { get; }
    public RoleManager<Cargo> RoleManager { get; }
    public AutenticacaoService(
        UserManager<Usuario> userManager, 
        SignInManager<Usuario> signInManager, 
        RoleManager<Cargo> roleManager
        )
    {

        UserManager = userManager;
        SignInManager = signInManager;
        RoleManager = roleManager;
    }



    public async Task<Result> RegistrarAsync(Usuario usuario, string senha, TipoUsuario tipoUsuario)
    {
        var usuarioResult = await UserManager.CreateAsync(usuario, senha);

        if(!usuarioResult.Succeeded)
        {
            var erros =  usuarioResult
                .Errors
                .Select(e => e.Description)
                .ToList();

            return Result.Fail(erros);
        }


        return Result.Ok();
    }
}
