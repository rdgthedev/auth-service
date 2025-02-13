using Auth_Service.Infrastructure;
using Auth_Service.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddDbContextConfigurations(builder.Configuration)
    .AddRepositories()
    .AddUnitOfWork()
    .LoadJwtSettings(builder.Configuration)
    .AddTokenService()
    .AddAuthService();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();