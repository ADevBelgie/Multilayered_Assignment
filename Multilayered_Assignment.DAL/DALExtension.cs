using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Multilayered_Assignment.Data;
using Multilayered_Assignment.DAL.Data.Repositories.Account;
using Multilayered_Assignment.DAL.Data.Repositories.ProductTShirtt;
using Multilayered_Assignment.DAL.Data.Repositories.ShoppingItem;
using Multilayered_Assignment.DAL.Data.Repositories.ShoppingBag;

namespace Multilayered_Assignment.DAL
{
    public static class DALExtension
    {
        public static IServiceCollection RegisterDAL(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<Multilayered_AssignmentContext>(options =>
                    options.UseSqlServer(config.GetConnectionString("Multilayered_Assignment")));

            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IProductTshirttRepository, ProductTshirttRepository>();
            services.AddTransient<IShoppingItemRepository, ShoppingItemRepository>();
            services.AddTransient<IShoppingBagRepository, ShoppingBagRepository>();

            return services;
        }
    }
}
