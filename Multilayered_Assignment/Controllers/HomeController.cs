using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Multilayered_Assignment.Data;
using Multilayered_Assignment.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Multilayered_Assignment.BLL.Services.ProductTShirtt;

namespace Multilayered_Assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductTshirttService _productTshirttService;

        public List<ProductTShirtViewModel> ProductList { get; set; } = new List<ProductTShirtViewModel>();

        public HomeController(ILogger<HomeController> logger, IProductTshirttService productTshirttService)
        {
            _logger = logger;
            _productTshirttService = productTshirttService;
        }

        public async Task<IActionResult> Index(int? id=1)
        {
            var productList = _productTshirttService.GetAllProductTshirtts();
            var onePageProduct = productList.FindAll(p => (p.ID >= id * 9 - 8) && (p.ID <= id * 9));

            ViewBag.PageId = id;
            ViewBag.TotalPages = (productList.Count()+8)/9;
            return View(onePageProduct);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
