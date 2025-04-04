using GoodWill.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoodWill.Infrastructure.DataAccess
{
    internal class GoodWillDbContext : DbContext
    {
        public GoodWillDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Transfer> Transfers { get; set; }

    }
}
