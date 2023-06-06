using System.Text.Json.Serialization;
using Core.Interfaces;
using Core.Providers;
using Core.Services;
using Infrastructure.Persistence;
using Infrastructure.Providers;
using Infrastructure.Repositories;
using Infrastructure.Services;

namespace API;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddRouting(options => options.LowercaseUrls = true);

        string connectionString = Configuration.GetConnectionString("DefaultConnection");
        
        services.AddSingleton(new DbContext(connectionString,"auth"));
        services.AddSingleton<IHasher, Hasher>();
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<IEmailProvider, EmailProvider>();
        services.AddSingleton<IAuthService, AuthService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            // Configure error handling for other environments
            // For example: app.UseExceptionHandler("/Home/Error");
        }

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}