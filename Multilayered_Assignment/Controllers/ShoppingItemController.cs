using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Multilayered_Assignment.Data;
using Multilayered_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Multilayered_Assignment.Controllers
{
    [Authorize]
    public class ShoppingItemController : Controller
    {
        private readonly Multilayered_AssignmentContext _context;

        public ShoppingItemController(Multilayered_AssignmentContext context)
        {
            _context = context;
        }

        // GET: Shoppingcart
        [Authorize]
        public async Task<IActionResult> Index()
        {
            //var productlist = await _context.ProductTShirtViewModel.ToListAsync();
            //var shoppingcart = await _context.ShoppingItemViewModel.ToListAsync();
            ////.Include(s => s.product.ID == productlist.Find(p => p.ID == ))
            dynamic mymodel = new ExpandoObject();
            mymodel.productlist = await _context.ProductTShirtViewModel.ToListAsync();
            mymodel.shoppingcart = await _context.ShoppingItemViewModel.ToListAsync();
            return View(mymodel);
        }
        [Authorize]
        public async Task<IActionResult> AddProductToCart(int id, int selectAmount = 1, string originC = "ShoppingItem", string originV = "Index")
        {
            var LoginUsers = await _context.LoginViewModel
                .ToListAsync();
            var ShoppingItems = await _context.ShoppingItemViewModel
                .ToListAsync();
            var Shoppingbags = await _context.ShoppingBagViewModel
                .ToListAsync();

            // Get id user
            var currentUser = LoginUsers.FirstOrDefault(l => l.UserName == User.Identity.Name);

            // Initialize tabel "ShoppingItemViewModel" if no records
            if (ShoppingItems == null)
            {
                ShoppingItems = new List<ShoppingItemViewModel>();
            }

            // Initialize tabel "ShoppingBagViewModel" if no records
            if (Shoppingbags == null)
            {
                Shoppingbags = new List<ShoppingBagViewModel>();
            }

            // Add shopping bag to user if it hasnt been added already
            if (currentUser.ShoppingBagId == 0)
            {
                // Add shopping bag
                _context.ShoppingBagViewModel.Add(new ShoppingBagViewModel()
                {
                    LoginId = currentUser.LoginId,
                    TimeCreated = DateTime.Now
                });

                await _context.SaveChangesAsync();


                // Add ShoppingBagId to LoginViewModel
                currentUser.ShoppingBagId = _context.ShoppingBagViewModel.FirstOrDefault(x => x.LoginId == currentUser.LoginId).ShoppingBagId;

                _context.LoginViewModel.Update(currentUser);
                await _context.SaveChangesAsync();
            }

            var productToAdd = ShoppingItems.Find(p => p.ProductId == id && p.ShoppingBagId == currentUser.ShoppingBagId);
            if (productToAdd != null)
            {
                productToAdd.Amount += selectAmount;
            }
            else
            {
                _context.Add(new ShoppingItemViewModel()
                {
                    ProductId = id,
                    ShoppingBagId = currentUser.ShoppingBagId,
                    Amount = selectAmount
                });
            }
            await _context.SaveChangesAsync();

            if (originV == "Details")
            {
                return RedirectToAction(originV, originC, new { id = id });
            }
            else
            {
                return RedirectToAction(originV, originC);
            }
        }
        [Authorize]
        public async Task<IActionResult> RemoveProductToCart(int id, string originC = "ShoppingItem", string originV = "Index")
        {
            var LoginUsers = await _context.LoginViewModel
                .ToListAsync();
            var ShoppingItems = await _context.ShoppingItemViewModel
                .ToListAsync();
            var Shoppingbags = await _context.ShoppingBagViewModel
                .ToListAsync();

            // Get id user
            var currentUser = LoginUsers.FirstOrDefault(l => l.UserName == User.Identity.Name);

            // Initialize tabel "ShoppingItemViewModel" if no records
            if (ShoppingItems == null)
            {
                ShoppingItems = new List<ShoppingItemViewModel>();
            }

            // Initialize tabel "ShoppingBagViewModel" if no records
            if (Shoppingbags == null)
            {
                Shoppingbags = new List<ShoppingBagViewModel>();
            }

            // Add shopping bag to user if it hasnt been added already
            if (currentUser.ShoppingBagId == 0)
            {
                // Add shopping bag
                _context.ShoppingBagViewModel.Add(new ShoppingBagViewModel()
                {
                    LoginId = currentUser.LoginId,
                    TimeCreated = DateTime.Now
                });

                await _context.SaveChangesAsync();


                // Add ShoppingBagId to LoginViewModel
                currentUser.ShoppingBagId = _context.ShoppingBagViewModel.FirstOrDefault(x => x.LoginId == currentUser.LoginId).ShoppingBagId;

                _context.LoginViewModel.Update(currentUser);
                await _context.SaveChangesAsync();
            }

            var shoppingItemToRemove = ShoppingItems.Find(p => p.ProductId == id && p.ShoppingBagId == currentUser.ShoppingBagId);
            if (shoppingItemToRemove != null)
            {
                _context.ShoppingItemViewModel.Remove(shoppingItemToRemove);
            }

            await _context.SaveChangesAsync();

            if (originV == "Details")
            {
                return RedirectToAction(originV, originC, new { id = id });
            }
            else
            {
                return RedirectToAction(originV, originC);
            }
        }
        [Authorize]
        private bool ShoppingcartViewModelExists(int id)
        {
            return _context.ShoppingItemViewModel.Any(e => e.ID == id);
        }
    }
}
