using LojaMariana.Dominio.ModuloCompra;
using LojaMariana.Dominio.Compartilhado;
using FluentResults;

namespace LojaMariana.Aplicacao.ModuloCompra;

public class CompraAppService
{
    private readonly IRepositorioCompra repositorioCompra;
    private readonly IUnitOfWork unitOfWork;

    public CompraAppService(IRepositorioCompra repositorioCompra, IUnitOfWork unitOfWork)
    {
        this.repositorioCompra = repositorioCompra;
        this.unitOfWork = unitOfWork;
    }

    public Result<Compra> Cadastrar(Compra compra)
    {
        repositorioCompra.CadastrarRegistro(compra);
        unitOfWork.Commit();
        return Result.Ok(compra);
    }

    public Result<List<Compra>> SelecionarTodos()
    {
        return Result.Ok(repositorioCompra.SelecionarRegistros());
    }

    public Result<Compra> SelecionarPorId(Guid id)
    {
        var compra = repositorioCompra.SelecionarRegistroPorId(id);

        if (compra == null)
            return Result.Fail("Compra não encontrada");

        return Result.Ok(compra);
    }
    public Result<Compra> Editar(Guid id, Compra compraEditada)
    {
        var compra = repositorioCompra.SelecionarRegistroPorId(id);

        if (compra == null)
            return Result.Fail("Compra não encontrada");

        repositorioCompra.EditarRegistro(id, compra);
        unitOfWork.Commit();

        return Result.Ok(compra);
    }

    public Result Excluir(Guid id)
    {
        var compra = repositorioCompra.SelecionarRegistroPorId(id);

        if (compra == null)
            return Result.Fail("Compra não encontrada");

        repositorioCompra.ExcluirRegistro(id);
        unitOfWork.Commit();

        return Result.Ok();
    }
}
