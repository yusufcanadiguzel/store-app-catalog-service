using Autofac;
using CatalogService.Application.DTOs;
using CatalogService.Application.Interfaces;
using CatalogService.Application.Services;
using CatalogService.Application.Validation.FluentValidation;
using CatalogService.Domain.Interfaces;
using CatalogService.Infrastructure.Persistence.Repositories;
using CatalogService.Infrastructure.Persistence.Repositories.EFCore;
using FluentValidation;

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

            // Validator Service Registration
            builder.RegisterType<FvProductValidator>().As<IValidator<ProductDtoForCreate>>().InstancePerLifetimeScope();
        }
    }
}
