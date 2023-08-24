using System.Text.Json.Serialization;
using API.Model.Providers.Phone.DTOs.Request;
using Autofac;
using DataAccessLayer;
using Entities.Models.Base;
using FluentValidation;
using FluentValidation.AspNetCore;
using Framework.Configuration;
using Framework.Mapper;
using Framework.Swagger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetailsFactory =
                        context.HttpContext.RequestServices.GetRequiredService<ProblemDetailsFactory>();
                    var problemDetails =
                        problemDetailsFactory.CreateValidationProblemDetails(context.HttpContext, context.ModelState,
                            422);

                    var result = new ObjectResult(problemDetails)
                    {
                        StatusCode = 422
                    };
                    return result;
                };
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        services.AddValidatorsFromAssembly(typeof(Program).Assembly);
        services.AddFluentValidationAutoValidation();

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