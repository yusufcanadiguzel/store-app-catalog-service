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
            builder.RegisterType<EfProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();

            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();

            builder.RegisterType<RepositoryManager>().As<IRepositoryService>().InstancePerLifetimeScope();

            builder.RegisterType<ServiceManager>().As<IServiceManager>().InstancePerLifetimeScope();
        }
    }
}
