using GoodWill.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static System.Formats.Asn1.AsnWriter;

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
