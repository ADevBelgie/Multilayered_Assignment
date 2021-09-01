using Multilayered_Assignment.Models;
using System.Collections.Generic;

namespace Multilayered_Assignment.BLL.Services.ShoppingBag
{
    public interface IShoppingBagService
    {
        List<ShoppingBagViewModel> GetAllShoppingBags();
        ShoppingBagViewModel GetShoppingBagByID(int id);
        ShoppingBagViewModel AddShoppingBag(ShoppingBagViewModel shoppingBag);
    }
}
