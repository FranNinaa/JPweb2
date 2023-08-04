using Microsoft.AspNetCore.Mvc;

namespace JPweb.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View("Login");
        }
    }
}
