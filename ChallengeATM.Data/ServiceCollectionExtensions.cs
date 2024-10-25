using ChallengeATM.Data.Repositories;
using ChallengeATM.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeATM.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddContext(configuration);

            services.AddRepositories();

            return services;
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICuentaRepository, CuentaRepository>();
            services.AddTransient<IOperacionRepository, OperacionRepository>();
            services.AddTransient<ITarjetaRepository, TarjetaRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        }

        public static void AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ChallengeATMContext") ?? throw new InvalidOperationException("Connection string 'ChallengeATMContext' not found");

            services.AddDbContext<ChallengeATMDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
