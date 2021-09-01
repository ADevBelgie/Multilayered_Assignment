using Multilayered_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilayered_Assignment.DAL.Data.Repositories.ShoppingBag
{
    public interface IShoppingBagRepository
    {
        IEnumerable<ShoppingBagViewModel> GetAllShoppingBags();
        ShoppingBagViewModel GetShoppingBagByID(int id);
        ShoppingBagViewModel AddShoppingBag(ShoppingBagViewModel shoppingBag);
        void Save();
    }
}
