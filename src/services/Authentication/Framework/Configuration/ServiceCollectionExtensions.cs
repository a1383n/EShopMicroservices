using Common;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Framework.Configuration;

public static class ServiceCollectionExtensions
{
    public static void AddDbContext(this IServiceCollection service, IConfiguration configuration)
    {
        //TODO: Move this out of this class
        var settings = configuration.GetSection("Settings").Get<Settings>();
        service.AddSingleton(settings);
        
        var dbSetting =
            MongoClientSettings.FromUrl(MongoUrl.Create(configuration.GetConnectionString("DefaultConnection")));
        var defaultDatabase = configuration.GetSection("Database")["Name"] ?? "auth";

        service.AddSingleton(new MongoDbContextFactory(dbSetting));

        //TODO: More research about how should register database context services. I believe it should be a singleton but the EF context registers itself scoped.
        //TODO: Also, if we register it as scoped, all classes that use database context such as repositories should also register as scoped.
        service.AddSingleton<IMongoDbContext>(provider =>
            provider.GetRequiredService<MongoDbContextFactory>().Create(defaultDatabase));
    }

    public static void AddCustomApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
        });
    }
}