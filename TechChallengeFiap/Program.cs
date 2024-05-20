using Microsoft.EntityFrameworkCore;
using TechChallengeFiap.Application.Configurations;
using TechChallengeFiap.Infrastructure.Contexto;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationDbContexto>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionSQLServer")));
builder.Services.AddSwaggerConfig();

var app = builder.Build();
app.UseSwaggerConfiguration(builder.Environment);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();