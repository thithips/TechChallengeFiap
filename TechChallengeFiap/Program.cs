using TechChallengeFiap.Application.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDependencyInjectionConfig(builder.Configuration);
builder.Services.AddSwaggerConfig();

var app = builder.Build();
app.UseSwaggerConfiguration(builder.Environment);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();