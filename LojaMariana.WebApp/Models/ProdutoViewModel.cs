using LojaMariana.Dominio.ModuloProduto;
using System.ComponentModel.DataAnnotations;

namespace LojaMariana.WebApp.Models
{
    public class ProdutoIndexViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Tamanho { get; set; }
        public Categoria Categoria { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string CodigoLive { get; set; }
    }

    public class CadastrarProdutoViewModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public string Tamanho { get; set; }

        [Required]
        public Categoria Categoria { get; set; }

        [Required]
        public int QuantidadeEstoque { get; set; }

        [Required]
        public string CodigoLive { get; set; }
    }

    public class EditarProdutoViewModel : CadastrarProdutoViewModel
    {
        public Guid Id { get; set; }

        public EditarProdutoViewModel() { }

        public EditarProdutoViewModel(Guid id, string nome, decimal preco, string tamanho, Categoria categoria, int quantidadeEstoque, string codigoLive)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Tamanho = tamanho;
            Categoria = categoria;
            QuantidadeEstoque = quantidadeEstoque;
            CodigoLive = codigoLive;
        }
    }

    public class ExcluirProdutoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public ExcluirProdutoViewModel() { }
        public ExcluirProdutoViewModel(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
