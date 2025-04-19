using GoodWill.Application.UseCases.Campaigns.Create;
using GoodWill.Application.UseCases.Campaigns.Delete;
using GoodWill.Application.UseCases.Campaigns.Update;
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
<<<<<<< HEAD
            services.AddScoped<IListAllCampaignUseCase, ListCampaignUseCase>();
            services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
            services.AddScoped<IListAllCampaignUseCase, ListCampaignUseCase>();
=======
            services.AddScoped<IDeleteCampaignUseCase, DeleteCampaignUseCase>();
            services.AddScoped<IEditCampaignUseCase, EditCampaignUseCase>();
>>>>>>> dfc9f990b3330d0c512c3ff47b3b872303f83538
        }
    }
}
