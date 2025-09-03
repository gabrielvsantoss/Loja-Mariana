using Microsoft.AspNetCore.Mvc;

namespace LojaMariana.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
