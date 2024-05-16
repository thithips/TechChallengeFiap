using Microsoft.EntityFrameworkCore;
using TechChallengeFiap.Domain.Entities;

namespace TechChallengeFiap.Infrastructure.Seeds
{
    public static class RegiaoSeed
    {
        public static void SeedsRegioes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Regiao>().HasData(new Regiao[] {
                new Regiao("Centro-oeste"),
            new Regiao("Sudeste"),
            new Regiao("Nordeste"),
            new Regiao("Sul"),
            new Regiao("Norte")
            });

        }
    }
}
