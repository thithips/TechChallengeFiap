using TechChallengeFiap.Core;
using TechChallengeFiap.Email.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/Cadastro", async (IEmailService emailService, EmailModel model) =>
{
    await emailService.SendEmailAsync(model);
    return Results.Ok();
}).WithOpenApi();

app.Run();