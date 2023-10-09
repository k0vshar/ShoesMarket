using ShoesMarket.DAL.Interfaces;
using ShoesMarket.DAL.Repositories;
using ShoesMarket.Domain.Entity;
using ShoesMarket.Service.Implementations;
using ShoesMarket.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ShoesMarket
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Shoes>, ShoesRepository>();
            services.AddScoped<IBaseRepository<User>, UserRepository>();
            services.AddScoped<IBaseRepository<Profile>, ProfileRepository>();
            services.AddScoped<IBaseRepository<Basket>, BasketRepository>();
            services.AddScoped<IBaseRepository<Order>, OrderRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IShoesService, ShoesService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
