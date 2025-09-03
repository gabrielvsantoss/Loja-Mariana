using LojaMariana.Dominio.ModuloCompra;
using LojaMariana.Dominio.ModuloProduto;

namespace LojaMariana.Dominio.ModuloCliente;
public class HistoricoCliente
{
    public List<Compra> Compras { get; set; }
    public Categoria CategoriaQueMaisComprou { get; set; }
    public decimal TotalGasto { get; set; }

    public HistoricoCliente()
    {
    }

    public void CalcularTotalGasto()
    {
        TotalGasto = 0;
        foreach (var compra in Compras)
        {
            TotalGasto += compra.ValorTotal;
        }
    }

    public void AdicionarCompra(Compra compra)
    {
        if (compra != null)
        Compras.Add(compra);
    }
    public void CalcularCategoriaMaisComprada()
    {
        var categoriaCount = new Dictionary<Categoria, int>();
        foreach (var compra in Compras)
        {
            foreach (var produto in compra.Produtos)
            {
                if (categoriaCount.ContainsKey(produto.Categoria))
                    categoriaCount[produto.Categoria]++;
                else
                    categoriaCount[produto.Categoria] = 1;
            }
        }
        CategoriaQueMaisComprou = categoriaCount.OrderByDescending(c => c.Value).FirstOrDefault().Key;
    }
}
