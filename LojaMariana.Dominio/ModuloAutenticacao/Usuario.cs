using Microsoft.AspNetCore.Identity;

namespace LojaMariana.Dominio.ModuloAutenticacao;

public class Usuario : IdentityUser<Guid>
{
    public Usuario()
    {
        Id = Guid.NewGuid();
        EmailConfirmed = true;
    }

    
}

public class InformacaoUsuario
{
    public required Guid Id { get; set; }
    public required string Email { get; set; }
}

public class Cargo : IdentityRole<Guid>
{

}
