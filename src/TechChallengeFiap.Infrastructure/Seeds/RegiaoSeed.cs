using Microsoft.EntityFrameworkCore;
using TechChallengeFiap.Domain.Entities;

namespace TechChallengeFiap.Infrastructure.Seeds
{
    public static class RegiaoSeed
    {
        public static void SeedsRegioes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Regiao>().HasData(new Regiao[] {
            new Regiao(new Guid("8B985725-487B-4A32-92A5-CB708F44C54B"),"Centro-oeste"),
            new Regiao(new Guid("6FB578F8-5176-4906-A805-3A100ADDE0C9"),"Sudeste"),
            new Regiao(new Guid("78FA8876-6C2D-4A09-B981-F77538F18FBB"),"Nordeste"),
            new Regiao(new Guid("667589E6-12E3-44DE-86CB-141058365C78"),"Sul"),
            new Regiao(new Guid("91EA2869-3FB0-4C39-8583-F420F8D48FA5"),"Norte")
            });
        }
    }
}
