using LojaMariana.Dominio.Compartilhado;
using LojaMariana.Dominio.ModuloCliente;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace LojaMariana.Aplicacao.ModuloCliente;

public class ClienteAppService
{
    private readonly IRepositorioCliente repositorioCliente;
    private readonly IUnitOfWork unitOfWork;
    private readonly ILogger<ClienteAppService> logger;

    public ClienteAppService(
        IRepositorioCliente repositorioCliente,
        IUnitOfWork unitOfWork,
        ILogger<ClienteAppService> logger)
    {
        this.repositorioCliente = repositorioCliente;
        this.unitOfWork = unitOfWork;
        this.logger = logger;
    }

    public Result Cadastrar(Cliente cliente)
    {
        try
        {
            repositorioCliente.CadastrarRegistro(cliente);
            unitOfWork.Commit();
            return Result.Ok();
        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "Erro ao cadastrar cliente {@Cliente}", cliente);
            return Result.Fail("Erro ao cadastrar cliente.");
        }
    }

    public Result Editar(Guid id, Cliente clienteEditado)
    {
        var cliente = repositorioCliente.SelecionarRegistroPorId(id);
        if (cliente == null)
            return Result.Fail($"Cliente {id} não encontrado.");

        try
        {
            cliente.AtualizarRegistro(clienteEditado);
            repositorioCliente.EditarRegistro(id, cliente);
            unitOfWork.Commit();
            return Result.Ok();
        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "Erro ao editar cliente {@Cliente}", clienteEditado);
            return Result.Fail("Erro ao editar cliente.");
        }
    }

    public Result Excluir(Guid id)
    {
        var cliente = repositorioCliente.SelecionarRegistroPorId(id);
        if (cliente == null)
            return Result.Fail($"Cliente {id} não encontrado.");

        try
        {
            repositorioCliente.ExcluirRegistro(id);
            unitOfWork.Commit();
            return Result.Ok();
        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();
            logger.LogError(ex, "Erro ao excluir cliente {Id}", id);
            return Result.Fail("Erro ao excluir cliente.");
        }
    }

    public Result<Cliente> SelecionarPorId(Guid id)
    {
        var cliente = repositorioCliente.SelecionarRegistroPorId(id);
        if (cliente == null)
            return Result.Fail($"Cliente {id} não encontrado.");

        return Result.Ok(cliente);
    }

    public Result<List<Cliente>> SelecionarTodos()
    {
        try
        {
            var clientes = repositorioCliente.SelecionarRegistros();
            return Result.Ok(clientes);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao selecionar clientes.");
            return Result.Fail("Erro ao selecionar clientes.");
        }
    }
}
