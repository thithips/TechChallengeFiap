using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallengeFiap.Domain.Entities;

namespace TechChallengeFiap.Infrastructure.Mapping
{
    public class ContatoMapping : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Telefone).HasColumnType("VARCHAR(11)").IsRequired();
            builder.Property(x => x.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.DataCriacao).HasColumnType("DATETIME").IsRequired();
            builder.Property(x => x.Email).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(x => x.IdDDD).IsRequired();

            builder.HasOne(x => x.DDD).WithMany(x => x.Contatos).HasForeignKey(x => x.IdDDD);
        }
    }
}
