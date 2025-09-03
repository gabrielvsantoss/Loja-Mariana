using LojaMariana.Dominio.ModuloCompra;
using LojaMariana.Infraestrutura.Orm.Compartilhado;

namespace LojaMariana.InfraestruturaEmOrm.ModuloCompra;
public class RepositorioCompraEmOrm : RepositorioBaseEmOrm<Compra>, IRepositorioCompra
{
    public RepositorioCompraEmOrm(lojaMarianaDbContext contexto) : base(contexto)
    {
    }
}

