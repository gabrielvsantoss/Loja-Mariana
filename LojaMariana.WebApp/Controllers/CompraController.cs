using LojaMariana.Aplicacao.ModuloCompra;
using LojaMariana.Dominio.ModuloCompra;
using LojaMariana.Dominio.ModuloCliente;
using LojaMariana.Dominio.ModuloProduto;
using LojaMariana.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaMariana.WebApp.Controllers;

[Route("compras")]
public class CompraController : Controller
{
    private readonly CompraAppService compraAppService;
    private readonly IRepositorioCliente repositorioCliente;
    private readonly IRepositorioProduto repositorioProduto;

    public CompraController(
        CompraAppService compraAppService,
        IRepositorioCliente repositorioCliente,
        IRepositorioProduto repositorioProduto)
    {
        this.compraAppService = compraAppService;
        this.repositorioCliente = repositorioCliente;
        this.repositorioProduto = repositorioProduto;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var resultado = compraAppService.SelecionarTodos();

        if (resultado.IsFailed)
            return View("Erro", resultado.Errors);

        var comprasVm = new CompraIndexViewModel
        {
            Compras = resultado.Value.Select(c => new CompraViewModel
            {
                Id = c.Id,
                Data = c.Data,
                ValorTotal = c.ValorTotal,
                ClienteNome = c.Cliente.Nome,
                Produtos = c.Produtos.Select(p => p.Nome).ToList()
            }).ToList()
        };

        return View(comprasVm);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        ViewBag.Clientes = repositorioCliente.SelecionarRegistros();
        ViewBag.Produtos = repositorioProduto.SelecionarRegistros();

        return View(new CadastrarCompraViewModel());
    }

    [HttpPost("cadastrar")]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastrar(CadastrarCompraViewModel vm)
    {
        var cliente = repositorioCliente.SelecionarRegistroPorId(vm.ClienteId);
        var produtos = repositorioProduto.SelecionarRegistros()
            .Where(p => vm.ProdutosIds.Contains(p.Id)).ToList();

        var compra = new Compra(produtos.Sum(p => p.Preco), vm.Data, cliente, produtos);


        var resultado = compraAppService.Cadastrar(compra);

        if (resultado.IsFailed)
        {
            ViewBag.Clientes = repositorioCliente.SelecionarRegistros();
            ViewBag.Produtos = repositorioProduto.SelecionarRegistros();
            return View(vm);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("excluir/{id:guid}")]
    public IActionResult Excluir(Guid id)
    {
        var resultado = compraAppService.SelecionarPorId(id);
        if (resultado.IsFailed)
            return RedirectToAction(nameof(Index));

        return View(resultado.Value);
    }

    [HttpPost("excluir/{id:guid}")]
    [ValidateAntiForgeryToken]
    public IActionResult ExcluirConfirmado(Guid id)
    {
        compraAppService.Excluir(id);
        return RedirectToAction(nameof(Index));
    }
}
