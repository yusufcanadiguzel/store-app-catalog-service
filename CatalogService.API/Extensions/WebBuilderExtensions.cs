using Autofac;
using Autofac.Extensions.DependencyInjection;
using CatalogService.Application.DependencyResolvers.Autofac;
using CatalogService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.API.Extensions
{
    public static class WebBuilderExtensions
    {
        public static void ConfigureSqlConnection(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<EfCatalogServiceDbContext>(options => options.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("CatalogConnection"), b => b.MigrationsAssembly("CatalogService.Infrastructure")));
        }

        public static void ConfigureDependencyResolver(this WebApplicationBuilder builder)
        {
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacDependencyModule()));
        }
    }
}
