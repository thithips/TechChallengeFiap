using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallengeFiap.Domain.Entities;

namespace TechChallengeFiap.Infrastructure.Mapping
{
    public class DDDMapping : IEntityTypeConfiguration<DDD>
    {
        public void Configure(EntityTypeBuilder<DDD> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NumeroDDD).HasColumnType("tinyint").IsRequired();
            builder.HasOne(x => x.Estado).WithMany(x => x.DDDs).HasForeignKey(x => x.IdEstado);
        }
    }
}
