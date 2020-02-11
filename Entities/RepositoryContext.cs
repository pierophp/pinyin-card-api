using Entities.Models;
using Innofactor.EfCoreJsonValueConverter;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Card> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Card>();
            builder.AddJsonFields();
        }
    }
}