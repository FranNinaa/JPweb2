using JPweb.Data.Repositorio.Interface;
using JPweb.Models;
using Microsoft.AspNetCore.Mvc;

namespace JPweb.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepositorio _loginRepositorio;


        public LoginController(ILoginRepositorio loginRepositorio)
        {
                _loginRepositorio = loginRepositorio;
        }

        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult BuscaLogin(Login login)
        {
            try
            {
               var acesso = _loginRepositorio.ValidarLogin(login);

                if (ModelState.IsValid)
                {

                    return RedirectToAction("Index", "Home");

                }
                return View("Index"); 


            }
            catch (Exception e)
            {

                TempData["MsgErro"] = $"Não conseguimos realizar seu loguin, tente novamente, erro: {e.Message}";
                return RedirectToAction("Index");
            }
          
        }
    }
}
