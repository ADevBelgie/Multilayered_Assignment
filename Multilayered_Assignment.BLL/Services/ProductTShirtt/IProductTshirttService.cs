using Multilayered_Assignment.Models;
using System.Collections.Generic;

namespace Multilayered_Assignment.BLL.Services.ProductTShirtt
{
    public interface IProductTshirttService
    {
        List<ProductTShirtViewModel> GetAllProductTshirtts();
        ProductTShirtViewModel GetProductTShirttByID(int id);
        ProductTShirtViewModel AddProductTShirtt(ProductTShirtViewModel productTShirtt);
        ProductTShirtViewModel UpdateProductTshirtt(ProductTShirtViewModel productTshirtt);
        void RemoveProductTshirtt(ProductTShirtViewModel productTshirtt);
    }
}
