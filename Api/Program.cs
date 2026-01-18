using Api.Extensions;
using Api.StartupConfigurations;
using Api.StartupConfigurations.Options;
using Domain;
using Keycloak;
using Keycloak.Configurations;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.RegisterKeycloakServices();
builder.Services.RegisterDataAccessService(builder.Configuration);

builder.Services.ConfigureOptions<KeycloakConfigurationSetup>();
builder.Services.ConfigureOptions<KeycloakScopesConfigurationSetup>();

builder.Services.AddKeycloakConfiguration();

builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new UlidJsonConverter());
});

builder.Services.ConfigureSwagger();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.MigrateDb();

app.ConfigureSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
