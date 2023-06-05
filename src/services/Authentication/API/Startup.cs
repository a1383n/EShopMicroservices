using Core.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;

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
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        string connectionString = Configuration.GetConnectionString("DefaultConnection");

        services.AddSingleton(new DbContext(connectionString,"auth"));
        services.AddSingleton<IUserRepository, UserRepository>();
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