using JPweb.Models;

namespace JPweb.Data.Repositorio.Interfaces
{
    public interface IAlunoRepositorio
    {
        List<Aluno> BuscarAlunos();

        void InserirAluno(Aluno aluno);

    }

}
