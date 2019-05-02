using AspnetRunAngular.Application.Interfaces;
using AspnetRunAngular.Core.Repositories;
using AspnetRunAngular.Core.Repositories.Base;
using AspnetRunAngular.Infrastructure.Data;
using AspnetRunAngular.Infrastructure.Repository;
using AspnetRunAngular.Infrastructure.Repository.Base;
using Autofac;
using FluentValidation;
using System.Linq;

namespace AspnetRunAngular.Api.Infrastructure.AutofacModules
{
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
            builder.RegisterType<IProductService>().As<IProductService>().InstancePerLifetimeScope();

            builder.RegisterType<AspnetRunContextSeed>();

            //TODO: you are here
            //// Register the Command's Validators (Validators based on FluentValidation library)
            //builder.RegisterAssemblyTypes(typeof(SaveAppointmentRequestValidator).GetTypeInfo().Assembly)
            //    .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
            //    .AsImplementedInterfaces();
        }
    }
}
