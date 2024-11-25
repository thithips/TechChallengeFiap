using Microsoft.EntityFrameworkCore;
using Prometheus;
using TechChallengeFiap.Application.Configurations;
using TechChallengeFiap.Infrastructure.Contexto;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDependencyInjectionConfig(builder.Configuration);
builder.Services.AddMetrics();
builder.Services.AddSwaggerConfig();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContexto>();
    if (db.Database.GetPendingMigrations().Any())
    {
        db.Database.Migrate();
    }
}

app.UseSwaggerConfiguration(builder.Environment);
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseMetricServer();
app.UseHttpMetrics();

app.MapControllers();

app.Run();