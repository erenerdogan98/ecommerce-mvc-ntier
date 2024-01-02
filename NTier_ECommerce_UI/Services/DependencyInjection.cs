using NTier_Ecommerce_BLL.Abstract;
using NTier_Ecommerce_BLL.Concrete;
using NTier_ECommerce_DAL.Abstract;
using NTier_ECommerce_DAL.Database;
using NTier_ECommerce_DAL.EFRepository;

namespace NTier_ECommerce_UI.Services
{
    public static class DependencyInjection
    {
        public static void ConfigureMyServices(this IServiceCollection services)
        {
            // I add services 
            services.AddDbContext<Context>();

            services.AddScoped<IActorsService, ActorsManager>();
            services.AddScoped<IActorsDAL, EFActorsRepository>();

            services.AddScoped<IMovieService, MovieManager>();
            services.AddScoped<IMovieDAL, EFMovieRepository>();

            services.AddScoped<ICinemaService, CinemaManager>();
            services.AddScoped<ICinemaDAL, EFCinemaRepostiory>();

            services.AddScoped<IProducerService, ProducerManager>();        
            services.AddScoped<IProducerDAL, EFProducerRepository>();
        }
    }
}
