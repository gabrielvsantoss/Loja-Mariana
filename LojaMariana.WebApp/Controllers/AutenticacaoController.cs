using LojaMariana.Aplicacao.ModuloAutenticacao;
using LojaMariana.Dominio.ModuloAutenticacao;
using LojaMariana.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LojaMariana.WebApp.Controllers
{
    [Route("autenticacao")]
    public class AutenticacaoController : Controller
    {
        private readonly AutenticacaoService autenticacaoService;

        public AutenticacaoController(AutenticacaoService autenticacaoService)
        {
            this.autenticacaoService = autenticacaoService;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            LoginViewModel loginVM = new LoginViewModel();
            return View(loginVM);
        }
        [HttpPost("login")]
        public IActionResult LoginPost(LoginViewModel loginVM)
        {
            return View();
        }

        [HttpGet("registro")]
        public IActionResult Registro()
        {
            RegistroViewModel registroVM = new RegistroViewModel();
            return View(registroVM);
        }
        [HttpPost("registro")]
        public async Task<IActionResult> Registro(RegistroViewModel registroVM)
        {
            var usuario = new Usuario
            {
                UserName = registroVM.Email,
                Email = registroVM.Email
            };
            var resultado = await autenticacaoService.RegistrarAsync
                (
                    usuario, registroVM.Senha ?? string.Empty, registroVM.TipoUsuario
                );

            if (resultado.IsSuccess)
                return View(nameof(Login));

            else
                return View(registroVM);
        }


    }
}
