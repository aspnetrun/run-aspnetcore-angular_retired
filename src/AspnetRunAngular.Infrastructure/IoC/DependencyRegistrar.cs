using AspnetRunAngular.Core.Interfaces;
using AspnetRunAngular.Core.Repositories;
using AspnetRunAngular.Core.Repositories.Base;
using AspnetRunAngular.Infrastructure.Data;
using AspnetRunAngular.Infrastructure.Logging;
using AspnetRunAngular.Infrastructure.Misc;
using AspnetRunAngular.Infrastructure.Repository;
using AspnetRunAngular.Infrastructure.Repository.Base;
using Autofac;

namespace AspnetRunAngular.Infrastructure.IoC
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            // repositories
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerDependency();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(EnumRepository<>)).As(typeof(IEnumRepository<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(RepositoryBase<,>)).As(typeof(IRepositoryBase<,>)).InstancePerDependency();

            builder.RegisterGeneric(typeof(LoggerAdapter<>)).As(typeof(IAppLogger<>)).InstancePerDependency();

            builder.RegisterType<AspnetRunContextSeed>();
        }

        public int Order => 1;
    }
}
