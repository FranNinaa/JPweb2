using JPweb.Models;

namespace JPweb.Data.Repositorio.Interfaces
{
    public interface IAlunoRepositorio
    {
        Aluno ListarPorId(int id);

        List<Aluno> BuscarAlunos();

        void InserirAluno(Aluno aluno);

        Aluno AtualizarAluno(Aluno aluno);

        bool Apagar(int Id);

    }

}
