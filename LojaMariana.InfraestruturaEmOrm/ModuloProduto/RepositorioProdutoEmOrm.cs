using LojaMariana.Dominio.ModuloProduto;
using LojaMariana.Infraestrutura.Orm.Compartilhado;

namespace LojaMariana.InfraestruturaEmOrm.ModuloProduto;
public class RepositorioProdutoEmOrm : RepositorioBaseEmOrm<Produto>, IRepositorioProduto
{
    public RepositorioProdutoEmOrm(lojaMarianaDbContext contexto) : base(contexto)
    {
    }
}

