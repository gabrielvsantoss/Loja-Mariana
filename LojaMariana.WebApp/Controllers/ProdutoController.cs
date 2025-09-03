    using Microsoft.AspNetCore.Mvc;

namespace LojaMariana.WebApp.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
