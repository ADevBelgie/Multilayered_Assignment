using Microsoft.Extensions.DependencyInjection;
using Multilayered_Assignment.BLL.Services.Account;
using Multilayered_Assignment.BLL.Services.ProductTShirtt;
using Multilayered_Assignment.BLL.Services.ShoppingBag;
using Multilayered_Assignment.BLL.Services.ShoppingItem;
using Multilayered_Assignment.BLL.Services.Discount;

namespace Multilayered_Assignment.BLL
{
    public static class BLLExtension
    {
        public static IServiceCollection RegisterBLL(this IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IProductTshirttService, ProductTshirttService>();
            services.AddTransient<IShoppingItemService, ShoppingItemService>();
            services.AddTransient<IShoppingBagService, ShoppingBagService>();
            services.AddTransient<IDiscountService, DiscountService>();

            return services;
        }
    }
}
