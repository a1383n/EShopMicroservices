using Microsoft.Extensions.DependencyInjection;

namespace Framework.Mapper;

public static class AutoMapperConfiguration
{
    public static void InitializeAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile(new ConventionalMappingProfile());
        });
    }
}