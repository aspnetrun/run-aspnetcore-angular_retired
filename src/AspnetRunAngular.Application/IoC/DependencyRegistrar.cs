using AspnetRunAngular.Application.Interfaces;
using AspnetRunAngular.Application.Services;
using AspnetRunAngular.Infrastructure.IoC;
using AspnetRunAngular.Infrastructure.Misc;
using Autofac;

namespace AspnetRunAngular.Application.IoC
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            // services
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
        }

        public int Order => 2;
    }
}
