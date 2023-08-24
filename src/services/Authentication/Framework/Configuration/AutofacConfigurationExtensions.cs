using System.Reflection;
using Autofac;
using Common;
using DataAccessLayer.Contracts.Base;
using DataAccessLayer.Repositories.Base;

namespace Framework.Configuration;

public static class AutofacConfigurationExtensions
{
    public static void AddServices(this ContainerBuilder builder, params Assembly[] assemblies)
    {
        builder
            .RegisterGeneric(typeof(Repository<>))
            .As(typeof(IRepository<>))
            .InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(assemblies)
            .AssignableTo<IScopedDependency>()
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(assemblies)
            .AssignableTo<ITransientDependency>()
            .AsImplementedInterfaces()
            .InstancePerDependency();

        builder.RegisterAssemblyTypes(assemblies)
            .AssignableTo<ISingletonDependency>()
            .AsImplementedInterfaces()
            .SingleInstance();
    }
}