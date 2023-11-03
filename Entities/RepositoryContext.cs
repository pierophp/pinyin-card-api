namespace PinyinCardApi.Entities;

using PinyinCardApi.Entities.Models;
using Innofactor.EfCoreJsonValueConverter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class RepositoryContext : DbContext
{
    // protected readonly IConfiguration Configuration;

    // public RepositoryContext(IConfiguration configuration)
    // {
    //     Configuration = configuration;
    // }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Card> Cards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new System.Version(8, 0, 11));

            var connectionString =
                "server=127.0.0.1;userid=root;password=root;database=pinyin_card;port=33061";
            if (connectionString == null)
            {
                throw new System.Exception("connectionString is null");
            }

            optionsBuilder.UseMySql(
                connectionString,
                serverVersion,
                options => options.UseMicrosoftJson()
            );
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Card>();
        // modelBuilder.AddJsonFields();

        modelBuilder.Entity<Category>().Property(c => c.Props).HasColumnType("json");

        // modelBuilder
        //     .Entity<Category>()
        //     .OwnsOne(
        //         category => category.Props,
        //         builder =>
        //         {
        //             builder.ToJson();
        //         }
        //     );
    }
}
