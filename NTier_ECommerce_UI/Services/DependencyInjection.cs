using NTier_Ecommerce_BLL.Abstract;
using NTier_Ecommerce_BLL.Concrete;
using NTier_ECommerce_DAL.Database;

namespace NTier_ECommerce_UI.Services
{
    public static class DependencyInjection
    {
        public static void Configure(this IServiceCollection services)
        {
            // I add services 
            services.AddDbContext<Context>();

            services.AddScoped<IActorsService, ActorsManager>();
            services.AddScoped<IMovieService, MovieManager>();
            services.AddScoped<ICinemaService, CinemaManager>();
            services.AddScoped<IProducerService, ProducerManager>();
        }
    }
}
