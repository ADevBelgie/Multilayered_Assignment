using Multilayered_Assignment.DAL.Data.Repositories.ProductTShirtt;
using Multilayered_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilayered_Assignment.BLL.Services.ProductTShirtt
{
    public class ProductTshirttService:IProductTshirttService
    {
        private readonly IProductTshirttRepository _productTshirttRepository;
        public ProductTshirttService(IProductTshirttRepository productTshirttRepository)
        {
            _productTshirttRepository = productTshirttRepository;
        }

        public ProductTShirtViewModel AddProductTShirtt(ProductTShirtViewModel productTShirtt)
        {
            var productTshirttToCheck = _productTshirttRepository.AddProductTshirtt(productTShirtt);

            return _productTshirttRepository.GetProductTshirttByID(productTshirttToCheck.ID);
        }

        public List<ProductTShirtViewModel> GetAllProductTshirtts()
        {
            return _productTshirttRepository.GetAllProductTshirtts().ToList();
        }

        public ProductTShirtViewModel GetProductTShirttByID(int id)
        {
            return _productTshirttRepository.GetProductTshirttByID(id);
        }
    }
}
