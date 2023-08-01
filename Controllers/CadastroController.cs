using Microsoft.AspNetCore.Mvc;

namespace JPweb.Controllers
{
    public class CadastroController : Controller
    {
        public IActionResult Index()
        {
            return View("Cadastro");
        }
    }
}
