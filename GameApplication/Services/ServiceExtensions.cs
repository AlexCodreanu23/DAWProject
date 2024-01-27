using Microsoft.Extensions.DependencyInjection;
using GameApplication.Repositories; 
namespace GameApplication.Services 
{
    public static class ServiceExtensions
    {
        public static void ConfigureMyServices(this IServiceCollection services)
        {
            services.AddScoped<IDevelopersRepository, DevelopersRepository>();
            services.AddScoped<IGamesRepository, GamesRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IReviewsRepository, ReviewsRepository>();
            services.AddScoped<IGameDevelopersRepository, GameDevelopersRepository>();
            services.AddScoped<ISystemRequirementsRepository, SystemRequirementsRepository>();
        }
    }
}
