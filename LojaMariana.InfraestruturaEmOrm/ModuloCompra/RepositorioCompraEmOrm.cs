using LojaMariana.Dominio.ModuloCompra;
using LojaMariana.Infraestrutura.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LojaMariana.InfraestruturaEmOrm.ModuloCompra;
public class RepositorioCompraEmOrm : RepositorioBaseEmOrm<Compra>, IRepositorioCompra
{
    public RepositorioCompraEmOrm(lojaMarianaDbContext contexto) : base(contexto)
    {
    }

    public override List<Compra> SelecionarRegistros()
    {
        return registros
            .Include(c => c.Cliente)
            .Include(c => c.Produtos)
            .ToList();
    }


    public override Compra? SelecionarRegistroPorId(Guid idRegistro)
    {
        return registros
            .Include(c => c.Cliente)
            .Include(c => c.Produtos)
            .FirstOrDefault(f => f.Id.Equals(idRegistro));
    }

}

