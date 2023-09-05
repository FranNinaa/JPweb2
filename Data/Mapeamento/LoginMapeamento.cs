using JPweb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPweb.Data.Mapeamento
{
    public class LoginMapeamento : IEntityTypeConfiguration<Login>
    {
       public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.ToTable("Login");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).HasColumnType("varchar(100)");
            builder.Property(x => x.Senha).HasColumnType("varchar(20)");
        }   
    }
}
