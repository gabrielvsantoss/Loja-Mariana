using LojaMariana.Dominio.Compartilhado;
using LojaMariana.Dominio.ModuloProduto;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace LojaMariana.Aplicacao.ModuloProduto
{
    public class ProdutoAppService
    {
        private readonly IRepositorioProduto repositorioProduto;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<ProdutoAppService> logger;

        public ProdutoAppService(
            IRepositorioProduto repositorioProduto,
            IUnitOfWork unitOfWork,
            ILogger<ProdutoAppService> logger)
        {
            this.repositorioProduto = repositorioProduto;
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public Result Cadastrar(Produto produto)
        {
            try
            {
                repositorioProduto.CadastrarRegistro(produto);
                unitOfWork.Commit();
                return Result.Ok();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                logger.LogError(ex, "Erro ao cadastrar produto {@Produto}", produto);
                return Result.Fail("Erro ao cadastrar produto.");
            }
        }

        public Result Editar(Guid id, Produto produtoEditado)
        {
            var produto = repositorioProduto.SelecionarRegistroPorId(id);
            if (produto == null)
                return Result.Fail($"Produto {id} não encontrado.");

            try
            {
                produto.AtualizarRegistro(produtoEditado);
                repositorioProduto.EditarRegistro(id, produto);
                unitOfWork.Commit();
                return Result.Ok();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                logger.LogError(ex, "Erro ao editar produto {@Produto}", produtoEditado);
                return Result.Fail("Erro ao editar produto.");
            }
        }

        public Result Excluir(Guid id)
        {
            var produto = repositorioProduto.SelecionarRegistroPorId(id);
            if (produto == null)
                return Result.Fail($"Produto {id} não encontrado.");

            try
            {
                repositorioProduto.ExcluirRegistro(id);
                unitOfWork.Commit();
                return Result.Ok();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                logger.LogError(ex, "Erro ao excluir produto {Id}", id);
                return Result.Fail("Erro ao excluir produto.");
            }
        }

        public Result<Produto> SelecionarPorId(Guid id)
        {
            var produto = repositorioProduto.SelecionarRegistroPorId(id);
            if (produto == null)
                return Result.Fail<Produto>($"Produto {id} não encontrado.");

            return Result.Ok(produto);
        }

        public Result<List<Produto>> SelecionarTodos()
        {
            try
            {
                var produtos = repositorioProduto.SelecionarRegistros();
                return Result.Ok(produtos);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao selecionar produtos.");
                return Result.Fail("Erro ao selecionar produtos.");
            }
        }
    }
}
