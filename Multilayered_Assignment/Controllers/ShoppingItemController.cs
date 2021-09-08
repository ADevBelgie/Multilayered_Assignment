using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Multilayered_Assignment.BLL.Services.Account;
using Multilayered_Assignment.BLL.Services.ShoppingBag;
using Multilayered_Assignment.BLL.Services.ShoppingItem;
using Multilayered_Assignment.BLL.Services.ProductTShirtt;
using Multilayered_Assignment.BLL.Services.Discount;
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
        private readonly IAccountService _accountService;
        private readonly IShoppingBagService _shoppingBagService;
        private readonly IShoppingItemService _shoppingItemService;
        private readonly IProductTshirttService _productTshirttService;
        private readonly IDiscountService _discountService;

        public ShoppingItemController(IAccountService accountService, IShoppingBagService shoppingBagService, IShoppingItemService shoppingItemService, IProductTshirttService productTshirttService, IDiscountService discountService)
        {
            _accountService = accountService;
            _shoppingBagService = shoppingBagService;
            _shoppingItemService = shoppingItemService;
            _productTshirttService = productTshirttService;
            _discountService = discountService;
        }

        // GET: Shoppingcart
        [Authorize]
        public async Task<IActionResult> Index()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.productList = _productTshirttService.GetAllProductTshirtts();
            mymodel.shoppingItems = _shoppingItemService.GetAllShoppingItems();//this current gives all shopping items not just of the curretn user
            return View(mymodel);
        }
        [Authorize]
        public async Task<IActionResult> AddProductToCart(int id, int selectAmount = 1, string originC = "ShoppingItem", string originV = "Index")
        {
            var LoginUsers = _accountService.GetAllLoginViews();
            var ShoppingItems = _shoppingItemService.GetAllShoppingItems();
            var Shoppingbags = _shoppingBagService.GetAllShoppingBags();

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

            // Add shopping bag to user if it cant find the bag trough ShoppingBagId
            AddShoppingBagToUser(currentUser, Shoppingbags);

            var productToUpdate = ShoppingItems.Find(p => p.ProductId == id && p.ShoppingBagId == currentUser.ShoppingBagId);
            if (productToUpdate != null)
            {
                productToUpdate.Amount += selectAmount;
                _shoppingItemService.UpdateShoppingItem(productToUpdate);
            }
            else
            {
                productToUpdate = _shoppingItemService.AddShoppingItem(new ShoppingItemViewModel()
                {
                    ProductId = id,
                    ShoppingBagId = currentUser.ShoppingBagId,
                    Amount = selectAmount
                });
            }
            // Add discount if needed
            AddDiscount(productToUpdate);

            if (originV == "Details")
            {
                return RedirectToAction(originV, originC, new { id = id });
            }
            else
            {
                return RedirectToAction(originV, originC);
            }
        }

        private void AddDiscount(ShoppingItemViewModel productToUpdate)
        {
            // Complexity for discount can be added.
            productToUpdate.Discount = _discountService.GetDiscountBulkBuy(productToUpdate.Amount);
            _shoppingItemService.UpdateShoppingItem(productToUpdate);
        }

        [Authorize]
        public async Task<IActionResult> RemoveProductToCart(int id, string originC = "ShoppingItem", string originV = "Index")
        {
            var LoginUsers = _accountService.GetAllLoginViews();
            var ShoppingItems = _shoppingItemService.GetAllShoppingItems();
            var Shoppingbags = _shoppingBagService.GetAllShoppingBags();

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

            // Add shopping bag to user if it cant find the bag trough ShoppingBagId
            AddShoppingBagToUser(currentUser, Shoppingbags);

            // Remove item from shoppingItems
            var shoppingItemToRemove = ShoppingItems.Find(p => p.ProductId == id && p.ShoppingBagId == currentUser.ShoppingBagId);
            if (shoppingItemToRemove != null)
            {
                _shoppingItemService.RemoveShoppingItem(shoppingItemToRemove);
            }

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
            return _shoppingItemService.GetAllShoppingItems().Any(e => e.ID == id);
        }
        private void AddShoppingBagToUser(LoginViewModel currentUser, List<ShoppingBagViewModel> Shoppingbags)
        {
            var currentBag = _shoppingBagService.GetAllShoppingBags().FirstOrDefault(x => x.ShoppingBagId == currentUser.ShoppingBagId);
            //if user doesnt have an exisiting bag linked to them 
            if (currentBag == null)
            {
                // create shopping bag if no bag with loginID is found
                currentBag = _shoppingBagService.GetAllShoppingBags().FirstOrDefault(x => x.LoginId == currentUser.LoginId);
                if (currentBag == null)
                {
                    currentBag = _shoppingBagService.AddShoppingBag(new ShoppingBagViewModel()
                    {
                        LoginId = currentUser.LoginId,
                        TimeCreated = DateTime.Now
                    });
                }
                
                // Add ShoppingBagId to LoginViewModel
                currentUser.ShoppingBagId = currentBag.ShoppingBagId;
                _accountService.UpdateLoginByID(currentUser);
            }
        }
    }
}
