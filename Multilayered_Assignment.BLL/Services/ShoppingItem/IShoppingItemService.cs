using Multilayered_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilayered_Assignment.BLL.Services.ShoppingItem
{
    public interface IShoppingItemService
    {
        List<ShoppingItemViewModel> GetAllShoppingItems();
        ShoppingItemViewModel GetShoppingItemByID(int id);
        ShoppingItemViewModel AddShoppingItem(ShoppingItemViewModel shoppingItem);
    }
}
