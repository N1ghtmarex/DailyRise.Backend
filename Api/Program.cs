using Api.Extensions;
using Api.Extensions.TelegramAuthentication;
using Api.StartupConfigurations.Options;
using Application;
using Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Xml.Linq;
using System.Xml.XPath;
using TgMiniAppAuth;

var builder = WebApplication.CreateBuilder(args);

// Добавляем аутентификацию
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "TelegramMiniApp";
    options.DefaultChallengeScheme = "TelegramMiniApp";
})
.AddScheme<AuthenticationSchemeOptions, TelegramAuthenticationHandler>(
    "TelegramMiniApp",
    options => { });

builder.Services.AddAuthorization();

// Настройка Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SchemaFilter<UlidSchemaFilter>();
    c.SchemaFilter<EnumSchemaFilter>();

    Directory
        .GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly)
        .ToList()
        .ForEach(xmlFile =>
        {
            var doc = XDocument.Load(xmlFile);
            c.IncludeXmlComments(() => new XPathDocument(doc.CreateReader()), includeControllerXmlComments: true);
        });

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Telegram Mini App API",
        Version = "v1",
        Description = "API for Telegram Mini Application"
    });

    // Добавляем поддержку кастомного заголовка авторизации
    c.AddSecurityDefinition("TelegramMiniApp", new OpenApiSecurityScheme
    {
        Description = "Telegram Mini App Authorization header using the TMiniApp scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "TMiniApp"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "TelegramMiniApp"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.RegisterUseCasesService();

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

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Telegram Mini App API v1");

    // Настраиваем поле для ввода заголовка авторизации в Swagger UI
    c.DefaultModelsExpandDepth(-1); // Скрываем модели
    c.DisplayRequestDuration();
});

app.UseHttpsRedirection();

app.MapControllers();

app.MigrateDb();

app.UseCors("CorsSetup");

app.UseAuthentication();
app.UseAuthorization();

app.Run();
