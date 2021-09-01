using Multilayered_Assignment.Data;
using Multilayered_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Multilayered_Assignment.DAL.Data.Repositories.ShoppingBag
{
    public class ShoppingBagRepository : IShoppingBagRepository
    {
        private readonly Multilayered_AssignmentContext _context;
        public ShoppingBagRepository(Multilayered_AssignmentContext context)
        {
            _context = context;
        }

        public ShoppingBagViewModel AddShoppingBag(ShoppingBagViewModel shoppingBag)
        {
            try
            {
                _context.ShoppingBagViewModel.Add(shoppingBag);
            }
            catch (Exception)
            {

                throw;
            }
            Save();
            return GetShoppingBagByID(shoppingBag.ShoppingBagId);
        }

        public IEnumerable<ShoppingBagViewModel> GetAllShoppingBags()
        {
            return _context.ShoppingBagViewModel;
        }

        public ShoppingBagViewModel GetShoppingBagByID(int id)
        {
            return _context.ShoppingBagViewModel.FirstOrDefault(x=>x.ShoppingBagId == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
