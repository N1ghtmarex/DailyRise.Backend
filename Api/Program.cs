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

builder.Services.AddCors(o => o.AddPolicy("AllowAll", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.MigrateDb();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.Run();
