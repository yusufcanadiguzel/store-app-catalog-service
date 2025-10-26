using CatalogService.API.Extensions;
using CatalogService.Application.Mapping.AutoMapper;
using NLog;

var builder = WebApplication.CreateBuilder(args);

// NLog Configuration
LogManager.Setup().LoadConfigurationFromFile(String.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));

// Add services to the container.

builder.Services.AddControllers()
    .AddApplicationPart(typeof(CatalogService.Presentation.AssemblyReference).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper Configuration
builder.Services.AddAutoMapper(cfg => { }, typeof(AmMappingProfile));

// Autofac Configuration
builder.ConfigureDependencyResolver();

// Register the DbContext
builder.ConfigureSqlConnection();

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
