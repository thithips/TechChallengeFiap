using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallengeFiap.Domain.Entities;

namespace TechChallengeFiap.Infrastructure.Mapping
{
    public class EstadoMapping : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).HasColumnType("VARCHAR(20)").IsRequired();
            builder.HasOne(x => x.Regiao).WithMany(x => x.Estados).HasForeignKey(x => x.IdRegiao);
        }
    }
}
