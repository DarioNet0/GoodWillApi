using GoodWill.Application.UseCases.Campaigns.Create;
using GoodWill.Application.UseCases.User.Create;
using Microsoft.Extensions.DependencyInjection;

namespace GoodWill.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCases(services);
        }
        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
            services.AddScoped<ICreateCampaignUseCase, CreateCampaignUseCase>();
        }
    }
}
