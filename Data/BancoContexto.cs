using JPweb.Data.Mapeamento;
using JPweb.Models;
using Microsoft.EntityFrameworkCore;

namespace JPweb.Data
{
    public class BancoContexto : DbContext
    {
        public BancoContexto(DbContextOptions<BancoContexto> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMapeamento());
        }

        public DbSet<Aluno> Aluno { get; set; }

        public DbSet<Login> Login { get; set; }
    }
}
