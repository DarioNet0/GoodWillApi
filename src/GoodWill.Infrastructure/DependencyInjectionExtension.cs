using GoodWill.Domain;
using GoodWill.Domain.Repositories.Campaign;
using GoodWill.Domain.Repositories.Transfer;
using GoodWill.Domain.Repositories.User;
using GoodWill.Domain.Security.Cryptography;
using GoodWill.Domain.Security.Token;
using GoodWill.Domain.Services.LoggedUsers;
using GoodWill.Infrastructure.DataAccess;
using GoodWill.Infrastructure.DataAccess.Repositories;
using GoodWill.Infrastructure.Security.Cryptography;
using GoodWill.Infrastructure.Security.Token;
using GoodWill.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoodWill.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILoggedUsers, LoggedUsers>();

            AddDbContext(services, configuration);
            AddRepository(services);
            AddSecurity(services, configuration);

        }
        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");

            services.AddDbContext<GoodWillDbContext>(config => config.UseNpgsql(connectionString));
        }
        public static void AddRepository(IServiceCollection services)
        {
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUserUpdateOnlyRepository, UserRepository>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();

            services.AddScoped<ICampaignReadOnlyRespository, CampaignRepository>();
            services.AddScoped<ICampaignUpdateOnlyRepository, CampaignRepository>();
            services.AddScoped<ICampaignWriteOnlyRepository, CampaignRepository>();

            services.AddScoped<ITransferWriteOnlyRepository, TransferRepository>();
            services.AddScoped<ITransferReadOnlyRespository, TransferRepository>();

            services.AddScoped<IUnityOfWork, UnityOfWork>();
        }
        public static void AddSecurity(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPasswordEncrypter, BCryptography>();

            var signInKey = configuration["Settings:Jwt:SignInKey"];
            var expirationTimeMinutes = uint.Parse(configuration["Settings:Jwt:ExpirationMinutes"]!);

            services.AddScoped<IAccessTokenGenerator>(config => new JwtTokenGenerator(expirationTimeMinutes, signInKey!));
        }

    }
}
