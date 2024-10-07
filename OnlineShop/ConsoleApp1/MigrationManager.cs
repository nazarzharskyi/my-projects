using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace ConsoleApp1
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                IMigrationRunner migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                migrationService.ListMigrations();
                migrationService.MigrateUp();
            }
            return host;
        }
    }
}