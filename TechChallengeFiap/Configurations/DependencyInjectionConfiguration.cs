using Microsoft.EntityFrameworkCore;
using TechChallengeFiap.Domain.Interfaces.Repository;
using TechChallengeFiap.Domain.Interfaces.Service;
using TechChallengeFiap.Infrastructure.Contexto;
using TechChallengeFiap.Infrastructure.Repository;
using TechChallengeFiap.Services;

namespace TechChallengeFiap.Application.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContexto>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("ConnectionSQLServer")));

            services.RegistraRepositories();
            services.RegistraServices();

            return services;
        }

        public static void RegistraRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDDDRepository, DDDRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IRegiaoRepository, RegiaoRepository>();
        }

        public static void RegistraServices(this IServiceCollection services)
        {
            services.AddScoped<IContatoService, ContatoService>();
            services.AddScoped<IDDDService, DDDService>();
            services.AddScoped<IRegiaoService, RegiaoService>();
        }
    }
}
