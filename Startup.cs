namespace PinyinCardApi;

using AutoMapper;
using PinyinCardApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Implementar logs https://code-maze.com/net-core-web-development-part3/


public class Startup
{
    public IConfigurationRoot Configuration { get; }

    public Startup(IWebHostEnvironment env)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) //load base settings
            .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true) //load local settings
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true) //load environment settings
            .AddEnvironmentVariables();

        Configuration = builder.Build();
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.ConfigureCors();
        // configure IIS ???? https://code-maze.com/net-core-web-development-part2
        services.ConfigureMySqlContext(Configuration);
        services.ConfigureRepositoryWrapper();
        services.AddControllers();
        services.AddAutoMapper(typeof(Startup));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseCors("CorsPolicy");

        app.UseForwardedHeaders(
            new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All }
        );

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
