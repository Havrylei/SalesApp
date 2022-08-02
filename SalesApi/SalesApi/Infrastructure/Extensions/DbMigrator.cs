using Microsoft.EntityFrameworkCore;

namespace SalesApi.Infrastructure.Extensions
{
    public static class DbMigrator
    {
        public static async Task MigrateAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<SalesDbContext>();

            await context.Database.MigrateAsync();
        }
    }
}
