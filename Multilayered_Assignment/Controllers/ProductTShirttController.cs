using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Multilayered_Assignment.Data;
using Multilayered_Assignment.Models;

namespace Multilayered_Assignment.Controllers
{
    [Authorize]
    public class ProductTShirttController : Controller
    {
        private readonly Multilayered_AssignmentContext _context;

        public ProductTShirttController(Multilayered_AssignmentContext context)
        {
            _context = context;
        }

        // GET: ProductTShirtt
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductTShirtViewModel.ToListAsync());
        }

        // GET: ProductTShirtt/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTShirtViewModel = await _context.ProductTShirtViewModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (productTShirtViewModel == null)
            {
                return NotFound();
            }

            return View(productTShirtViewModel);
        }

        // GET: ProductTShirtt/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductTShirtt/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Price,Picture")] ProductTShirtViewModel productTShirtViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productTShirtViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productTShirtViewModel);
        }

        // GET: ProductTShirtt/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTShirtViewModel = await _context.ProductTShirtViewModel.FindAsync(id);
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
        [Authorize]
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
                    _context.Update(productTShirtViewModel);
                    await _context.SaveChangesAsync();
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
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTShirtViewModel = await _context.ProductTShirtViewModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (productTShirtViewModel == null)
            {
                return NotFound();
            }

            return View(productTShirtViewModel);
        }

        // POST: ProductTShirtt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productTShirtViewModel = await _context.ProductTShirtViewModel.FindAsync(id);
            _context.ProductTShirtViewModel.Remove(productTShirtViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductTShirtViewModelExists(int id)
        {
            return _context.ProductTShirtViewModel.Any(e => e.ID == id);
        }
    }
}
