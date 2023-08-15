using Microsoft.AspNetCore.Mvc;

namespace JPweb.Controllers
{
    public class ProfessorController : Controller
    {
        public IActionResult Index()
        {
            return View("Professor");
        }
    }
}
