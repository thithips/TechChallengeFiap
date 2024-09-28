using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TechChallengeFiap.Domain.Entities;
using TechChallengeFiap.Infrastructure.Seeds;

namespace TechChallengeFiap.Infrastructure.Contexto
{
    public class ApplicationDbContexto : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<DDD> DDDs { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Regiao> Regioes { get; set; }

        public ApplicationDbContexto(DbContextOptions<ApplicationDbContexto> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

            RegiaoSeed.SeedsRegioes(modelBuilder);
            EstadoSeed.SeedsEstados(modelBuilder);
            DDDSeed.SeedsDDDs(modelBuilder);
        }
        
        //add-migration adicionaBaseInicial; update-database
    }
}
