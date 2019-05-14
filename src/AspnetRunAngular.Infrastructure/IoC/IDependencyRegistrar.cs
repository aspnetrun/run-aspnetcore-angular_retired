using AspnetRunAngular.Infrastructure.Misc;
using Autofac;

namespace AspnetRunAngular.Infrastructure.IoC
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder, ITypeFinder typeFinder);

        int Order { get; }
    }
}
