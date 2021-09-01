using Multilayered_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilayered_Assignment.DAL.Data.Repositories.ShoppingItem
{
    public interface IShoppingItemRepository
    {
        IEnumerable<ShoppingItemViewModel> GetAllShoppingItems();
        ShoppingItemViewModel GetShoppingItemByID(int id);
        void RemoveShoppingItem(ShoppingItemViewModel shoppingItem);
        ShoppingItemViewModel AddShoppingItem(ShoppingItemViewModel shoppingItem);
        ShoppingItemViewModel UpdateShoppingItem(ShoppingItemViewModel shoppingItem);
        void Save();
    }
}
