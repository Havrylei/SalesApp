using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SalesApi.Infrastructure.Extensions
{
    public static class DbMigrator
    {
        public static async Task MigrateAsync(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<SalesDbContext>();

            await context.Database.MigrateAsync();
        }
    }
}
