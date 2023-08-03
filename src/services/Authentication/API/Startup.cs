using System.Text.Json.Serialization;
using Autofac;
using DataAccessLayer;
using Entities.Models.Base;
using Framework.Configuration;
using Framework.Mapper;
using Framework.Swagger;
using Services.Contracts;

namespace API;

public class Startup
{
    private IConfiguration _configuration { get; }
    private readonly IWebHostEnvironment _environment;


    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
        _configuration = configuration;
        _environment = environment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.InitializeAutoMapper();
        services.AddDbContext(_configuration);
        
        if (_environment.IsDevelopment())
        {
            services.AddSwagger();
        }

        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        services.AddEndpointsApiExplorer();
        services.AddCustomApiVersioning();

        services.AddRouting(options => options.LowercaseUrls = true);
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
        var assemblies = new[]
        {
            typeof(IEntity).Assembly,
            typeof(IMongoDbContext).Assembly,
            typeof(IAuthService).Assembly
        };

        builder.AddServices(assemblies);
    }

    public void Configure(IApplicationBuilder app)
    {
        //TODO: Add custom exception handler

        if (_environment.IsProduction())
        {
            app.UseHttpsRedirection();
            app.UseHsts();
        }
        else if (_environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();   
        }

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}