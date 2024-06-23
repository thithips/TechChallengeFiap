using Microsoft.OpenApi.Models;
using System.Reflection;

namespace TechChallengeFiap.Application.Configurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                    c.IncludeXmlComments(xmlPath);

                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "TechChallengeFiap - Cadastro de contatos",
                    Version = "v1",
                    Description = "Este projeto foi realizado pelos alunos Fernanda Diniz, Thiago Alves e Vinicius Nascimento para o curso Arquitetura de Sistemas .NET com Azure da FIAP"
                });
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            return app;
        }
    }
}
