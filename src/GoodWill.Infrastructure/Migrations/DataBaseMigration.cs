using GoodWill.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GoodWill.Infrastructure.Migrations
{
    public static class DataBaseMigration
    {
        public static async Task MigrateDatabase(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<GoodWillDbContext>();

            await dbContext.Database.MigrateAsync();
        }
    }
}
