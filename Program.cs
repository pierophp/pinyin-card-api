namespace PinyinCardApi;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Entities;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Program
{
    public static void Main(string[] args)
    {
        JsonSerializerOptions options =
            new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

        CreateHostBuilder(args).Build().MigrateDatabase().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
