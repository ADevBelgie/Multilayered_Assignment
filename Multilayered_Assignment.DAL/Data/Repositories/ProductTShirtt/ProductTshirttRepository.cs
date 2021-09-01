using Multilayered_Assignment.Data;
using Multilayered_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Multilayered_Assignment.DAL.Data.Repositories.ProductTShirtt
{
    public class ProductTshirttRepository : IProductTshirttRepository
    {
        private readonly Multilayered_AssignmentContext _context;
        public ProductTshirttRepository(Multilayered_AssignmentContext context)
        {
            _context = context;
        }

        public ProductTShirtViewModel AddProductTshirtt(ProductTShirtViewModel productTshirtt)
        {
            try
            {
                _context.ProductTShirtViewModel.Add(productTshirtt);
            }
            catch (Exception)
            {

                throw;
            }
            Save();
            return GetProductTshirttByID(productTshirtt.ID);
        }

        public IEnumerable<ProductTShirtViewModel> GetAllProductTshirtts()
        {
            return _context.ProductTShirtViewModel;
        }

        public ProductTShirtViewModel GetProductTshirttByID(int id)
        {
            return _context.ProductTShirtViewModel.FirstOrDefault(x => x.ID == id);
        }

        public void RemoveProductTshirtt(ProductTShirtViewModel productTshirtt)
        {
            _context.ProductTShirtViewModel.Remove(productTshirtt);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public ProductTShirtViewModel UpdateProductTshirtt(ProductTShirtViewModel productTshirtt)
        {
            _context.ProductTShirtViewModel.Update(productTshirtt);
            Save();
            return GetProductTshirttByID(productTshirtt.ID);
        }
    }
}
