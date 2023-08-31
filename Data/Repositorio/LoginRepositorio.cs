using JPweb.Data.Repositorio.Interface;
using JPweb.Models;

namespace JPweb.Data.Repositorio
{
    public class LoginRepositorio : ILoginRepositorio
    {
        private readonly BancoContexto _bancoContexto;

        public LoginRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }
        public Login ValidarLogin(Login login)
        {
            return _bancoContexto.Login.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
        }
    }
   
}
