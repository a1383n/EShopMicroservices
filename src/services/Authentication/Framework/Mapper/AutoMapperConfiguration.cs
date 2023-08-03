using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Mapper;

public static class AutoMapperConfiguration
{
    private static void AddCustomMappingProfile(this IMapperConfigurationExpression expression,
        params Assembly[] assemblies)
    {
        var allTypes = assemblies.SelectMany(assembly => assembly.ExportedTypes);
        var list = allTypes
            .Where(type => type is { IsClass: true, IsAbstract: false } && type.GetInterfaces().Contains(typeof(IMappable)))
            .Select(type => (IMappable)Activator.CreateInstance(type)!);

        expression.AddProfile(new CustomMappingProfile(list));
    }

    public static void InitializeAutoMapper(this IServiceCollection service, params Assembly[] assemblies)
    {
        service.AddAutoMapper(expression => expression.AddCustomMappingProfile(assemblies),assemblies);
    }
}