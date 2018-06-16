using Autofac;

namespace MyStore.Infrastructure
{
    public static class InfrastructureContainer
    {
        public static void Update(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(InfrastructureContainer).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}