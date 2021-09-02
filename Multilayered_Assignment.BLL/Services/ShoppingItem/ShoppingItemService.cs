using Multilayered_Assignment.DAL.Data.Repositories.ShoppingItem;
using Multilayered_Assignment.Models;
using System.Collections.Generic;
using System.Linq;

namespace Multilayered_Assignment.BLL.Services.ShoppingItem
{
    public class ShoppingItemService : IShoppingItemService
    {
        private readonly IShoppingItemRepository _shoppingItemRepository;
        public ShoppingItemService(IShoppingItemRepository shoppingItemRepository)
        {
            _shoppingItemRepository = shoppingItemRepository;
        }
        public ShoppingItemViewModel AddShoppingItem(ShoppingItemViewModel shoppingItem)
        {
            var shoppingItemToCheck = _shoppingItemRepository.AddShoppingItem(shoppingItem);

            return _shoppingItemRepository.GetShoppingItemByID(shoppingItemToCheck.ID);
        }

        public List<ShoppingItemViewModel> GetAllShoppingItems()
        {
            return _shoppingItemRepository.GetAllShoppingItems().ToList();
        }

        public ShoppingItemViewModel GetShoppingItemByID(int id)
        {
            return _shoppingItemRepository.GetShoppingItemByID(id);
        }

        public void RemoveShoppingItem(ShoppingItemViewModel shoppingItem)
        {
            _shoppingItemRepository.RemoveShoppingItem(shoppingItem);
        }

        public ShoppingItemViewModel UpdateShoppingItem(ShoppingItemViewModel shoppingItem)
        {
            return _shoppingItemRepository.UpdateShoppingItem(shoppingItem);
        }
    }
}
