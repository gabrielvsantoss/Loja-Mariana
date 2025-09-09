using LojaMariana.Dominio.Compartilhado;
using LojaMariana.Dominio.ModuloCliente;
using LojaMariana.Dominio.ModuloProduto;

namespace LojaMariana.Dominio.ModuloCompra;

public class Compra : EntidadeBase<Compra>
{
    public decimal ValorTotal { get; private set; }
    public DateTime Data { get; private set; }

    public Cliente Cliente { get; private set; }

    public ICollection<Produto> Produtos { get; private set; } = new List<Produto>();

    protected Compra() { }

    public Compra(decimal valorTotal, DateTime data, Cliente cliente, List<Produto> produtos)
    {
        Id = Guid.NewGuid();
        ValorTotal = valorTotal;
        Data = DateTime.SpecifyKind(data, DateTimeKind.Utc);
        Cliente = cliente;
        Produtos = produtos ?? new List<Produto>();
    }
    public override void AtualizarRegistro(Compra registroEditado)
    {
        ValorTotal = registroEditado.ValorTotal;
        Data = registroEditado.Data;
        Cliente = registroEditado.Cliente;
        Produtos = registroEditado.Produtos ?? new List<Produto>();
    }
}
