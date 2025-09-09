using LojaMariana.Dominio.ModuloProduto;
using LojaMariana.Dominio.ModuloCliente;
using System.ComponentModel.DataAnnotations;

namespace LojaMariana.WebApp.Models;

public class CompraViewModel
{
    public Guid Id { get; set; }
    public DateTime Data { get; set; }
    public decimal ValorTotal { get; set; }
    public string ClienteNome { get; set; }
    public List<string> Produtos { get; set; } = new();
}

public class CompraIndexViewModel
{
    public List<CompraViewModel> Compras { get; set; } = new();
}

public class CadastrarCompraViewModel
{
    [Required]
    public Guid ClienteId { get; set; }

    [Required]
    public List<Guid> ProdutosIds { get; set; } = new();

    [Required]
    [DataType(DataType.Date)]
    public DateTime Data { get; set; }
}

public class HistoricoClienteViewModel
{
    public string CategoriaLabel { get; set; }
    public int CategoriaValor { get; set; }

    public string DiaLabel { get; set; }
    public int DiaValor { get; set; }

    public string TamanhoLabel { get; set; }
    public int TamanhoValor { get; set; }
}

