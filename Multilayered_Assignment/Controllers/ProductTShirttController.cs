using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Multilayered_Assignment.BLL.Services.ProductTShirtt;
using Multilayered_Assignment.Models;

namespace Multilayered_Assignment.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductTShirttController : Controller
    {
        private readonly IProductTshirttService _productTshirttService;

        public ProductTShirttController(IProductTshirttService productTshirttService)
        {
            _productTshirttService = productTshirttService;
        }

        // GET: ProductTShirtt
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            return View(_productTshirttService.GetAllProductTshirtts());
        }

        // GET: ProductTShirtt/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTShirtViewModel = _productTshirttService.GetAllProductTshirtts()
                .FirstOrDefault(m => m.ID == id);
            if (productTShirtViewModel == null)
            {
                return NotFound();
            }

            return View(productTShirtViewModel);
        }

        // GET: ProductTShirtt/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductTShirtt/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("ID,Name,Price,Picture")] ProductTShirtViewModel productTShirtViewModel)
        {
            if (ModelState.IsValid)
            {
                _productTshirttService.AddProductTShirtt(productTShirtViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(productTShirtViewModel);
        }

        // GET: ProductTShirtt/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productTShirtViewModel = _productTshirttService.GetProductTShirttByID((int)id);
            if (productTShirtViewModel == null)
            {
                return NotFound();
            }
            return View(productTShirtViewModel);
        }

        // POST: ProductTShirtt/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Price,Picture")] ProductTShirtViewModel productTShirtViewModel)
        {
            if (id != productTShirtViewModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _productTshirttService.UpdateProductTshirtt(productTShirtViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductTShirtViewModelExists(productTShirtViewModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productTShirtViewModel);
        }

        // GET: ProductTShirtt/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTShirtViewModel = _productTshirttService.GetAllProductTshirtts()
                .FirstOrDefault(m => m.ID == id);
            if (productTShirtViewModel == null)
            {
                return NotFound();
            }

            return View(productTShirtViewModel);
        }

        // POST: ProductTShirtt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var productTShirtViewModel = _productTshirttService.GetProductTShirttByID(id);
            _productTshirttService.RemoveProductTshirtt(productTShirtViewModel);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductTShirtViewModelExists(int id)
        {
            return _productTshirttService.GetAllProductTshirtts().Any(e => e.ID == id);
        }
    }
}
