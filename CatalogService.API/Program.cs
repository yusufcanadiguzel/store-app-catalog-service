using CatalogService.API.Extensions;
using CatalogService.Application.Interfaces;
using NLog;

var builder = WebApplication.CreateBuilder(args);

// NLog configuration
LogManager.Setup().LoadConfigurationFromFile(String.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));

// Add services to the container.

builder.Services.AddControllers()
    .AddApplicationPart(typeof(CatalogService.Presentation.AssemblyReference).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Autofac Configuration
builder.ConfigureDependencyResolver();

// Register the DbContext
builder.ConfigureSqlConnection();

var app = builder.Build();

// Configure custom exception middleware
var loggerService = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(loggerService);

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

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
