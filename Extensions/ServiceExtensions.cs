namespace PinyinCardApi.Extensions;

using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(
                "CorsPolicy",
                builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );
        });
    }

    public static void ConfigureMySqlContext(
        this IServiceCollection services,
        IConfiguration config
    )
    {
        // services.AddDbContext<RepositoryContext>(options =>
        // {
        //     var connectionString = config["mysqlconnection:connectionString"];
        //     if (connectionString == null)
        //     {
        //         throw new System.Exception("connectionString is null");
        //     }

        //     DbContextOptionsConfigurer.Configure(options, connectionString);
        // });

        // var serverVersion = new MySqlServerVersion(new System.Version(8, 0, 11));
        // var connectionString = config["mysqlconnection:connectionString"];
        // services.AddDbContextPool<RepositoryContext>(
        //     optionsBuilder =>
        //         optionsBuilder.UseMySql(
        //             connectionString,
        //             serverVersion,
        //             options => options.UseMicrosoftJson()
        //         )
        // );
    }

    public static void ConfigureRepositoryWrapper(this IServiceCollection services)
    {
        // services.AddScoped<RepositoryWrapper, RepositoryWrapper>();
    }
}
