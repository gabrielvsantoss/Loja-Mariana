using LojaMariana.Dominio.Compartilhado;

namespace LojaMariana.Dominio.ModuloProduto;

public  class Produto : EntidadeBase<Produto>
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public string Tamanho { get; set; }
    public Categoria Categoria { get; set; }
    public int QuantidadeEstoque { get; set; }
    public string CodigoLive { get; set; }

    public Produto()
    {

    }
    public Produto(string nome, decimal preco, string tamanho, Categoria categoria, int quantidadeEstoque, string codigoLive)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Preco = preco;
        Tamanho = tamanho;
        Categoria = categoria;
        QuantidadeEstoque = quantidadeEstoque;
        CodigoLive = codigoLive;
    }

    public override void AtualizarRegistro(Produto registroEditado)
    {
        Nome = registroEditado.Nome;
        Preco = registroEditado.Preco;
        Tamanho = registroEditado.Tamanho;
        Categoria = registroEditado.Categoria;
        QuantidadeEstoque = registroEditado.QuantidadeEstoque;
        CodigoLive = registroEditado.CodigoLive;
    }
}
