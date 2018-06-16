using Autofac;

namespace MyStore.Services
{
    public static class ServicesContainer
    {
        public static void Update(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ServicesContainer).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}