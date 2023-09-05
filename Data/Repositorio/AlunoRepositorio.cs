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


        public Aluno ListarPorId(int id)
        {
            return _bancoContexto.Aluno.FirstOrDefault(x => x.Id == id);
        }

       


        public Aluno Atualizar(Aluno aluno)
        {
            Aluno alunoDb = ListarPorId(aluno.Id);

            if (alunoDb == null) throw new System.Exception("Houve um erro na atualização do Aluno !");
            
            alunoDb.Nome = aluno.Nome;
            alunoDb.Matricula = aluno.Matricula;
            alunoDb.Curso = aluno.Curso;
            alunoDb.Cep = aluno.Cep;
            alunoDb.Endereco = aluno.Endereco;
            alunoDb.DataNascimento = aluno.DataNascimento;

            _bancoContexto.Aluno.Update(alunoDb);
            _bancoContexto.SaveChanges();

            return alunoDb;
        }

        public bool Apagar(int Id)
        {
            Aluno alunoDb = ListarPorId(Id);

            if (alunoDb == null)
            {
                throw new System.Exception("Erro em Deletar esse Aluno !");
            }
            _bancoContexto.Aluno.Remove(alunoDb);
            _bancoContexto.SaveChanges();

            return true;
        }

        public List<Aluno> BuscarAlunos()
        {
            return _bancoContexto.Aluno.ToList();
        }

        public Aluno Adicionar(Aluno aluno)
        {
            _bancoContexto.Aluno.Add(aluno);
            _bancoContexto.SaveChanges();
            return aluno;
        }

       

        
    }
}
