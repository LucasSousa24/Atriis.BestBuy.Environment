using BestBuy.Abstractions.Interfaces;
using BestBuy.Abstractions.Models;
using BestBuy.Core.Extensions.Configurations;
using BestBuy.EFCore.Extensions.Configurations;
using BestBuy.ExternalAPI.Extensions.Configuration;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Localization;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
                // Add Fluent Validation
                .AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Swagger
var assemblyLocation = typeof(Program).GetTypeInfo().Assembly.Location;

if (builder.Environment.IsDevelopment())
{
    FileVersionInfo _fileVersionInfo = FileVersionInfo.GetVersionInfo(assemblyLocation);

    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Version = _fileVersionInfo.ProductVersion,
            Title = "Best Buy API",
            Description = "Best Buy API developed by Lucas Sousa",
            Contact = new Microsoft.OpenApi.Models.OpenApiContact
            {
                Name = "Lucas Sousa",
                Email = "lucasdejesussasousa@gmail.com"
            }
        });

        c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "BestBuy.Abstractions.xml"));
        c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "BestBuy.API.xml"));
    });
}

var configurationSettings = builder.Configuration.GetSection("Settings").Get<ConfigurationSettings>();
builder.Services.AddSingleton<IConfigurationSettings>(configurationSettings);

// Business
builder.Services.AddCore();

// Storage
builder.Services.AddStorage();

// Provider
builder.Services.AddExternalAPIService();

//Localization
builder.Services.AddLocalization();
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
                    new CultureInfo("en-US"),
                    new CultureInfo("pt-PT")
                };

    options.DefaultRequestCulture = new RequestCulture("en-US", "en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
