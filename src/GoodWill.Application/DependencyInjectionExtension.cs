using GoodWill.Application.UseCases.Campaigns.Create;
using GoodWill.Application.UseCases.User.Create;
using Microsoft.Extensions.DependencyInjection;
using GoodWill.Application.UseCases.Campaigns.List;
using GoodWill.Application.UseCases.Login;

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
            services.AddScoped<IListAllCampaignUseCase, ListCampaignUseCase>();
            services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
            services.AddScoped<IListAllCampaignUseCase, ListCampaignUseCase>();
        }
    }
}
