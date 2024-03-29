﻿using NTier_Ecommerce_BLL.Abstract;
using NTier_Ecommerce_BLL.Concrete;
using NTier_ECommerce_DAL.Abstract;
using NTier_ECommerce_DAL.Database;
using NTier_ECommerce_DAL.EFRepository;
using AutoMapper;
using NTier_ECommerce_UI.Mapping;
using NTier_Ecommerce_BLL.Cart;
using NTier_ECommerce_Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

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

            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IOrderDAL, EFOrderRepository>();

            services.AddScoped<IShoppingCartService, ShoppingCart>();
            services.AddScoped<IShoppingDAL, EFShoppingCartRepository>();

            services.AddScoped(sp =>
            {
                // Obtaining the IShoppingDAL service (using dependency injection)
                var shoppingDAL = sp.GetRequiredService<IShoppingDAL>();

                // Creating an instance of IShoppingCartService
                return new ShoppingCart(shoppingDAL);
            });

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<Context>();
            services.AddMemoryCache();
            services.AddSession();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });
            services.AddControllersWithViews();

            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
