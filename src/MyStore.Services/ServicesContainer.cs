using Autofac;
using Microsoft.AspNetCore.Identity;
using MyStore.Core.Domain;

namespace MyStore.Services
{
    public static class ServicesContainer
    {
        public static void Update(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ServicesContainer).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterType<PasswordHasher<User>>()
                .As<IPasswordHasher<User>>();
            builder.RegisterInstance(AutoMapperConfig.GetMapper())
                .SingleInstance();
        }
    }
}