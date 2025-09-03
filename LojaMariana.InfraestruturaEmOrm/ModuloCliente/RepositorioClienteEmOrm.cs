using LojaMariana.Dominio.ModuloCliente;
using LojaMariana.Infraestrutura.Orm.Compartilhado;

namespace LojaMariana.InfraestruturaEmOrm.ModuloCliente;
public class RepositorioClienteEmOrm : RepositorioBaseEmOrm<Cliente>, IRepositorioCliente
{
    public RepositorioClienteEmOrm(lojaMarianaDbContext contexto) : base(contexto)
    {
    }
}

