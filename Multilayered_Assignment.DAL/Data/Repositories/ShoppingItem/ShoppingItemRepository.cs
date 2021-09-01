using Multilayered_Assignment.Data;
using Multilayered_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Multilayered_Assignment.DAL.Data.Repositories.ShoppingItem
{
    public class ShoppingItemRepository : IShoppingItemRepository
    {
        private readonly Multilayered_AssignmentContext _context;
        public ShoppingItemRepository(Multilayered_AssignmentContext context)
        {
            _context = context;
        }
        public ShoppingItemViewModel AddShoppingItem(ShoppingItemViewModel shoppingItem)
        {
            try
            {
                _context.ShoppingItemViewModel.Add(shoppingItem);
            }
            catch (Exception)
            {

                throw;
            }
            Save();
            return GetShoppingItemByID(shoppingItem.ID);
        }

        public IEnumerable<ShoppingItemViewModel> GetAllShoppingItems()
        {
            return _context.ShoppingItemViewModel;
        }

        public ShoppingItemViewModel GetShoppingItemByID(int id)
        {
            return _context.ShoppingItemViewModel.FirstOrDefault(x => x.ID == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
