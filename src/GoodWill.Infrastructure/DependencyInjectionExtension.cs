using GoodWill.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoodWill.Infrastructure
{
    public static class DependencyInjectionExtension 
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
        }
        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");

            services.AddDbContext<GoodWillDbContext>(config => config.UseSqlServer(connectionString));
        }

    }
}
