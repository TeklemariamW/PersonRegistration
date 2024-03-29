using Azure.Identity;
using Entities;
using Interfaces;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace PeopleRegistration.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
        });
    }

    public static void ConfigureIISIntegration(this IServiceCollection services)
    {
        services.Configure<IISOptions>(options =>
        {

        });
    }

    public static void ConfigureLoggerService(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerManager, LoggerManager>();
    }

    public static void ConfigureRepositoryWrapper(this IServiceCollection services, IHostEnvironment envi, IConfiguration config)
    {
        string accountEndpoint = config["ConnectionString:CosmosDB:AccountKey"];
        string databaseid = config["ConnectionString:CosmosDB:DatabaseId"];

        if (envi.IsDevelopment())
        {
            services.AddDbContext<RepositoryContext>(delegate (DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseCosmos(accountEndpoint, databaseid);
                optionsBuilder.EnableDetailedErrors();
                optionsBuilder.EnableSensitiveDataLogging();
            });
        }

        if(envi.IsProduction())
        {
            services.AddDbContext<RepositoryContext>(delegate (DbContextOptionsBuilder options)
            {
                options.UseCosmos(accountEndpoint, new DefaultAzureCredential(), databaseid);
            });
        }

        services.AddScoped<IPersonRepository, PersonRepository>();
    }
}