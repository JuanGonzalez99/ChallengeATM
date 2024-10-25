using ChallengeATM.Business.Services;
using ChallengeATM.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeATM.Business
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddServices();

            return services;
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<IOperacionService, OperacionService>();
            services.AddTransient<ITarjetaService, TarjetaService>();
        }
    }
}
