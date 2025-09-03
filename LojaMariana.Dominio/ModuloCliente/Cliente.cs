using LojaMariana.Dominio.Compartilhado;

namespace LojaMariana.Dominio.ModuloCliente;
public class Cliente : EntidadeBase<Cliente>
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
    public string Email { get; set; }

    public Cliente()
    {

    }
    public Cliente(string nome, string telefone, string endereco, string email)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Telefone = telefone;
        Endereco = endereco;
        Email = email;
    }

    public override void AtualizarRegistro(Cliente registroEditado)
    {
        Nome = registroEditado.Nome;
        Telefone = registroEditado.Telefone;
        Endereco = registroEditado.Endereco;
        Email = registroEditado.Email;
    }

}