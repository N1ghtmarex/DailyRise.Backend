using Api.Extensions;
using Domain;
using Microsoft.AspNetCore.Mvc;
using TgMiniAppAuth;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

builder.Services.AddTgMiniAppAuth(builder.Configuration);

builder.Services.AddControllers();

builder.Services.RegisterDataAccessService(builder.Configuration);

builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new UlidJsonConverter());
});

builder.Services.AddCors(o => o.AddPolicy("CorsSetup", builder =>
{
    builder.WithOrigins(
        "https://beverlee-overoptimistic-caroyln.ngrok-free.dev",
        "http://localhost:8080",
        "https://daily-rise.ru")
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials();
}));

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.MigrateDb();

app.UseCors("CorsSetup");

app.UseAuthentication();
app.UseAuthorization();

app.Run();
