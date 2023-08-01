using Microsoft.AspNetCore.Mvc;

namespace JPweb.Controllers
{
    public class AlunoController : Controller
    {
        public IActionResult Index()
        {
            return View("Aluno");
        }
    }
}
