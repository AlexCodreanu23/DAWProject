using Microsoft.Extensions.DependencyInjection;
using GameApplication.Repositories; 
namespace GameApplication.Services 
{
    public static class ServiceExtensions
    {
        public static void ConfigureMyServices(this IServiceCollection services)
        {
            services.AddScoped<IDevelopersRepository, DevelopersRepository>();

        }
    }
}
