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

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Email).HasColumnType("varchar(100)");
            builder.Property(t => t.Senha).HasColumnType("varchar(20)");
        }   
    }
}
