using Multilayered_Assignment.DAL.Data.Repositories.ShoppingBag;
using Multilayered_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilayered_Assignment.BLL.Services.ShoppingBag
{
    public class ShoppingBagService : IShoppingBagService
    {
        private readonly IShoppingBagRepository _shoppingBagRepository;
        public ShoppingBagService(IShoppingBagRepository shoppingBagRepository)
        {
            _shoppingBagRepository = shoppingBagRepository;
        }

        public ShoppingBagViewModel AddShoppingBag(ShoppingBagViewModel shoppingBag)
        {
            var shoppingBagToCheck = _shoppingBagRepository.AddShoppingBag(shoppingBag);

            return _shoppingBagRepository.GetShoppingBagByID(shoppingBagToCheck.ShoppingBagId);
        }

        public List<ShoppingBagViewModel> GetAllShoppingBags()
        {
            return _shoppingBagRepository.GetAllShoppingBags().ToList();
        }

        public ShoppingBagViewModel GetShoppingBagByID(int id)
        {
            return _shoppingBagRepository.GetShoppingBagByID(id);
        }
    }
}
