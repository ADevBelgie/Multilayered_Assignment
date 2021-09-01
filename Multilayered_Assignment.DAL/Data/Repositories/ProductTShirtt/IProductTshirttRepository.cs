using Multilayered_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilayered_Assignment.DAL.Data.Repositories.ProductTShirtt
{
    public interface IProductTshirttRepository
    {
        IEnumerable<ProductTShirtViewModel> GetAllProductTshirtts();
        ProductTShirtViewModel GetProductTshirttByID(int id);
        ProductTShirtViewModel AddProductTshirtt(ProductTShirtViewModel productTshirtt);
        ProductTShirtViewModel UpdateProductTshirtt(ProductTShirtViewModel productTshirtt);
        void RemoveProductTshirtt(ProductTShirtViewModel productTshirtt);
        void Save();
    }
}
