using JPweb.Data.Repositorio.Interfaces;
using JPweb.Models;

namespace JPweb.Data.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {



        private readonly BancoContexto _bancoContexto;



        public AlunoRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }



        public List<Aluno> BuscarAlunos()
        {
            return _bancoContexto.Aluno.ToList();
        }
        public void InserirAluno(Aluno aluno)
        {
            _bancoContexto.Aluno.Add(aluno);
            _bancoContexto.SaveChanges();
        }



    }
}
