using JPweb.Models;

namespace JPweb.Data.Repositorio.Interfaces
{
    public interface IAlunoRepositorio
    {
        Aluno ListarPorId(int id);

        List<Aluno> BuscarAlunos();

        Aluno Adicionar(Aluno aluno);

        Aluno Atualizar(Aluno aluno);

        bool Apagar(int Id);

    }

}
