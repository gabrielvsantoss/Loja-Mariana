using LojaMariana.Aplicacao.ModuloProduto;
using LojaMariana.Dominio.ModuloProduto;
using LojaMariana.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaMariana.WebApp.Controllers;

[Route("produtos")]
public class ProdutoController : Controller
{
    private readonly ProdutoAppService produtoAppService;

    public ProdutoController(ProdutoAppService produtoAppService)
    {
        this.produtoAppService = produtoAppService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var resultado = produtoAppService.SelecionarTodos();
        if (resultado.IsFailed)
            return View("Erro", resultado.Errors);

        var produtosVm = resultado.Value.Select(p => new ProdutoIndexViewModel
        {
            Id = p.Id,
            Nome = p.Nome,
            Preco = p.Preco,
            Tamanho = p.Tamanho,
            Categoria = p.Categoria,
            QuantidadeEstoque = p.QuantidadeEstoque,
            CodigoLive = p.CodigoLive
        }).ToList();

        return View(produtosVm);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        return View(new CadastrarProdutoViewModel());
    }

    [HttpPost("cadastrar")]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastrar(CadastrarProdutoViewModel cadastrarVm)
    {
        var produto = new Produto(
            cadastrarVm.Nome,
            cadastrarVm.Preco,
            cadastrarVm.Tamanho,
            cadastrarVm.Categoria,
            cadastrarVm.QuantidadeEstoque,
            cadastrarVm.CodigoLive
        );

        var resultado = produtoAppService.Cadastrar(produto);

        if (resultado.IsFailed)
            return View(cadastrarVm);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("editar/{id:guid}")]
    public IActionResult Editar(Guid id)
    {
        var resultado = produtoAppService.SelecionarPorId(id);
        if (resultado.IsFailed)
            return RedirectToAction(nameof(Index));

        var p = resultado.Value;
        var editarVm = new EditarProdutoViewModel(p.Id, p.Nome, p.Preco, p.Tamanho, p.Categoria, p.QuantidadeEstoque, p.CodigoLive);

        return View(editarVm);
    }

    [HttpPost("editar/{id:guid}")]
    [ValidateAntiForgeryToken]
    public IActionResult Editar(Guid id, EditarProdutoViewModel editarVm)
    {
        var produtoEditado = new Produto(editarVm.Nome, editarVm.Preco, editarVm.Tamanho, editarVm.Categoria, editarVm.QuantidadeEstoque, editarVm.CodigoLive);
        var resultado = produtoAppService.Editar(id, produtoEditado);

        if (resultado.IsFailed)
            return View(editarVm);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("excluir/{id:guid}")]
    public IActionResult Excluir(Guid id)
    {
        var resultado = produtoAppService.SelecionarPorId(id);
        if (resultado.IsFailed)
            return RedirectToAction(nameof(Index));

        var p = resultado.Value;
        return View(new ExcluirProdutoViewModel(p.Id, p.Nome));
    }

    [HttpPost("excluir/{id:guid}")]
    [ValidateAntiForgeryToken]
    public IActionResult Excluir(ExcluirProdutoViewModel excluirVm)
    {
        var resultado = produtoAppService.Excluir(excluirVm.Id);
        return RedirectToAction(nameof(Index));
    }
}
