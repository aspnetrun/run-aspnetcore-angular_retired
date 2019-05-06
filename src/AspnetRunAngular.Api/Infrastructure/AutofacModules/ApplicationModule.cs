using AspnetRunAngular.Api.Application.Validations;
using AspnetRunAngular.Application.Interfaces;
using AspnetRunAngular.Application.Services;
using AspnetRunAngular.Core.Repositories;
using AspnetRunAngular.Core.Repositories.Base;
using AspnetRunAngular.Infrastructure.Data;
using AspnetRunAngular.Infrastructure.Repository;
using AspnetRunAngular.Infrastructure.Repository.Base;
using Autofac;
using FluentValidation;
using System.Linq;
using System.Reflection;

namespace AspnetRunAngular.Api.Infrastructure.AutofacModules
{
    //TODO: Each layer should have own autofac module
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // repositories
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerDependency();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(EnumRepository<>)).As(typeof(IEnumRepository<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(RepositoryBase<,>)).As(typeof(IRepositoryBase<,>)).InstancePerDependency();

            // services
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();

            builder.RegisterType<AspnetRunContextSeed>();

            // Register the Command's Validators (Validators based on FluentValidation library)
            builder.RegisterAssemblyTypes(typeof(CreateProductRequestValidator).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();
        }
    }
}
