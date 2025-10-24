using Autofac;
using CatalogService.Application.Interfaces;
using CatalogService.Application.Services;
using CatalogService.Domain.Interfaces;
using CatalogService.Infrastructure.Persistence.Repositories;
using CatalogService.Infrastructure.Persistence.Repositories.EFCore;

namespace CatalogService.Application.DependencyResolvers.Autofac
{
    public class AutofacDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Product Entity Registrations
            builder.RegisterType<EfProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();

            // Repository Service Registration
            builder.RegisterType<RepositoryManager>().As<IRepositoryService>().InstancePerLifetimeScope();
            builder.RegisterType<ServiceManager>().As<IServiceManager>().InstancePerLifetimeScope();

            // Logger Service Registration
            builder.RegisterType<LoggerManager>().As<ILoggerService>().SingleInstance();
        }
    }
}
