using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallengeFiap.Domain.Entities;

namespace TechChallengeFiap.Infrastructure.Mapping
{
    public class RegiaoMapping : IEntityTypeConfiguration<Regiao>
    {
        public void Configure(EntityTypeBuilder<Regiao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).HasColumnType("VARCHAR(15)");
        }
    }
}
