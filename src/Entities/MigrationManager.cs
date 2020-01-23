using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var repositoryContext = scope.ServiceProvider.GetRequiredService<RepositoryContext>())
                {
                    repositoryContext.Database.Migrate();
                }
            }

            return host;
        }
    }
}