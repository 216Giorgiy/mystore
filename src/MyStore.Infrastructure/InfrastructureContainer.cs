using Autofac;
using MyStore.Core.Repositories;
using MyStore.Infrastructure.EF;

namespace MyStore.Infrastructure
{
    public static class InfrastructureContainer
    {
        public static void Update(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(InfrastructureContainer).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterType<EfProductRepository>()
                .As<IProductRepository>()
                .InstancePerLifetimeScope();
        }
    }
}