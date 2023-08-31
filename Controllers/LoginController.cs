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

        public IActionResult BuscaLogin(Login login)
        {
            try
            {
               var acesso = _loginRepositorio.ValidarLogin(login);

                if (acesso != null)
                {

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    TempData["MsgErro"] = "Usuário ou senha incorreto !! Tente Novamente ...";
                }

            }
            catch (Exception)
            {

                TempData["MsgErro"] = "Erro ao Buscar dados do banco";
            }
            return View("Index");
        }
    }
}
