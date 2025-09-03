using LojaMariana.Aplicacao.ModuloCliente;
using LojaMariana.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LojaMariana.WebApp.Controllers
{
    [Route("clientes")]
    public class ClienteController : Controller
    {
        private readonly ClienteAppService clienteAppService;

        public ClienteController(ClienteAppService clienteAppService)
        {
            this.clienteAppService = clienteAppService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var resultado = clienteAppService.SelecionarTodos();

            if (resultado.IsFailed)
                return View("Erro", resultado.Errors);

            var clientesVm = new ClienteIndexViewModel
            {
                Clientes = resultado.Value.Select(c => new ClienteViewModel
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Telefone = c.Telefone,
                    Endereco = c.Endereco,
                    Email = c.Email
                }).ToList()
            };

            return View(clientesVm);
        }

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            return View(new CadastrarClienteViewModel());
        }

        [HttpPost("cadastrar")]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(CadastrarClienteViewModel cadastrarVm)
        {
            var cliente = new LojaMariana.Dominio.ModuloCliente.Cliente(
                cadastrarVm.Nome,
                cadastrarVm.Telefone,
                cadastrarVm.Endereco,
                cadastrarVm.Email
            );

            var resultado = clienteAppService.Cadastrar(cliente);

            if (resultado.IsFailed)
                return View(cadastrarVm);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar/{id:guid}")]
        public IActionResult Editar(Guid id)
        {
            var resultado = clienteAppService.SelecionarPorId(id);
            if (resultado.IsFailed)
                return RedirectToAction(nameof(Index));

            var cliente = resultado.Value;
            var editarVm = new EditarClienteViewModel(cliente.Id, cliente.Nome, cliente.Telefone, cliente.Endereco, cliente.Email);

            return View(editarVm);
        }

        [HttpPost("editar/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Guid id, EditarClienteViewModel editarVm)
        {
            var clienteEditado = new LojaMariana.Dominio.ModuloCliente.Cliente(
                editarVm.Nome,
                editarVm.Telefone,
                editarVm.Endereco,
                editarVm.Email
            );

            var resultado = clienteAppService.Editar(id, clienteEditado);

            if (resultado.IsFailed)
                return View(editarVm);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("excluir/{id:guid}")]
        public IActionResult Excluir(Guid id)
        {
            var resultado = clienteAppService.SelecionarPorId(id);
            if (resultado.IsFailed)
                return RedirectToAction(nameof(Index));

            var cliente = resultado.Value;
            return View(new ExcluirClienteViewModel(cliente.Id, cliente.Nome));
        }

        [HttpPost("excluir/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(ExcluirClienteViewModel excluirVm)
        {
            var resultado = clienteAppService.Excluir(excluirVm.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
