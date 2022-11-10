using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using onlineShop.Models;
using onlineShop.Repository;
using onlineShop.ViewModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NdlovuCode.PaginatedList;
using onlineShop.Extensions;

namespace onlineShop.Controllers
{
    public class HomeController : BaseController
    {
        private readonly string cartKey =$"CartItem";
        private readonly string counterKey =$"CartCounter";
        private readonly string totalItems =$"Items";
        private readonly string orderKey = $"order";
        private readonly ILogger<HomeController> _logger;
        private IRepo repo;
        private readonly ICustomer _customer;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IOrder _order;
        private List<CartViewModel> listOfShoppingCartModels;

        public HomeController(ILogger<HomeController> logger,IRepo repo,ICustomer customer,UserManager<IdentityUser> userManager,IOrder order)
        {
            _logger = logger;
            this.repo = repo;
            _customer = customer;
            _userManager = userManager;
            _order = order;
            listOfShoppingCartModels = new List<CartViewModel>();
        }

        public IActionResult Index(string searchValue, string desert,int page = 1)
        {
            PaginatedList<ProductViewModel> pagePaginatedList =
                PaginatedList<ProductViewModel>.Create(repo.getAllProducts(), page, repo.getAllProducts().Count);
            if (string.IsNullOrEmpty(searchValue))
            {
                return View(pagePaginatedList);
            }
            
            var mypage = pagePaginatedList.Filter(searchValue, "Name");
            if (mypage.Count == 0)
            {
                notify("Product Not Available");
            }
            return View(mypage);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Profile()
        {
            
            return View(new Customer());
        }

        [HttpPost]
        public IActionResult Profile(Customer customer)
        {
            customer.Email = _userManager.GetUserName(HttpContext.User);
            _customer.AddCustomer(customer,_userManager.GetUserId(HttpContext.User));
            notify("Customer registered");
           return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public IActionResult ShoppingCart()
		{
            var userId = _userManager.GetUserId(HttpContext.User);
			var cart = HttpContext.Session.Get<List<CartViewModel>>(cartKey+$"-{userId}");
            return View(cart);
		}
        // [HttpPost]
        // public IActionResult ShoppingCart(string id)
        // {
        //     // var userId = _userManager.GetUserId(HttpContext.User);
        //     // HttpContext.Session.Set<string>($"custom-{userId}",processor.CustomAngraving);
        //     return RedirectToAction("CheckOut");
        // }


		[HttpPost]
        public JsonResult Index(string ItemId)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            CartViewModel objShoppingCartModel = new CartViewModel();
            var objPro = repo.getInventory(int.Parse(ItemId));
			 if (!string.IsNullOrEmpty(HttpContext.Session.GetString(counterKey+$"-{userId}")))
			 {
				listOfShoppingCartModels = HttpContext.Session.Get<List<CartViewModel>>(cartKey+$"-{userId}");
			 }
        
           
            if (listOfShoppingCartModels != null && listOfShoppingCartModels.Any(model => model.ItemId == ItemId))
            {
                objShoppingCartModel = listOfShoppingCartModels.Single(model => model.ItemId == ItemId);
                objShoppingCartModel.Quantity += 1;
                objShoppingCartModel.Total = objShoppingCartModel.Quantity * objShoppingCartModel.UnitPrice;
            }
            else
            {
                objShoppingCartModel.ItemId = ItemId;
                objShoppingCartModel.ItemName = objPro.ProdName;
                objShoppingCartModel.Quantity = 1;
                objShoppingCartModel.Total = objPro.ProdPrice;
                objShoppingCartModel.UnitPrice = objPro.ProdPrice;
                objShoppingCartModel.ImageUrl = objPro.ImageUrl;
                listOfShoppingCartModels.Add(objShoppingCartModel);
            }

			HttpContext.Session.Set<int>(counterKey+$"-{userId}",listOfShoppingCartModels.Count);
			HttpContext.Session.Set<List<CartViewModel>>(cartKey+$"-{userId}",listOfShoppingCartModels);
            // SaveCartTotalToSession(listOfShoppingCartModels);
            return Json(new { Success = true, Counter = listOfShoppingCartModels.Count });
        }


		public ActionResult Remove(int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            List<CartViewModel> cart = HttpContext.Session.Get<List<CartViewModel>>(cartKey+$"-{userId}");
            foreach(var item in cart)
            {
                if(item.ItemId == id.ToString())
                {
                    cart.Remove(item);
                    break;
                }
            }
            
           HttpContext.Session.Set<List<CartViewModel>>(cartKey+$"-{userId}",cart);
           HttpContext.Session.Set<int>(counterKey+$"-{userId}",cart.Count);
            if (cart == null)
            {
				HttpContext.Session.Set<List<CartViewModel>>(cartKey,null);
            }
           // SaveCartTotalToSession(cart);

            return RedirectToAction("ShoppingCart","Home");
        }

        public ActionResult Plus(int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            List<CartViewModel> cart = HttpContext.Session.Get<List<CartViewModel>>(cartKey+$"-{userId}");
            foreach (var item in cart)
            {
                if (item.ItemId == id.ToString())
                {
                    item.Quantity = item.Quantity + 1;
                    item.Total = item.Quantity * item.UnitPrice;
                   
                }
            }
           	HttpContext.Session.Set<List<CartViewModel>>(cartKey+$"-{userId}",cart);
            //SaveCartTotalToSession(cart);
            return RedirectToAction("ShoppingCart", "Home");
        }
		public ActionResult Minus(int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
             List<CartViewModel> cart = HttpContext.Session.Get<List<CartViewModel>>(cartKey+$"-{userId}");
            foreach (var item in cart)
            {
                if (item.ItemId == id.ToString() && item.Quantity !=1) 
                {
                    item.Quantity = item.Quantity - 1;
                    item.Total = item.Quantity * item.UnitPrice;
                   
                }
            }
           	HttpContext.Session.Set<List<CartViewModel>>(cartKey+$"-{userId}",cart);
            //SaveCartTotalToSession(cart);
            return RedirectToAction("ShoppingCart", "Home");
        }
        
        // [Authorize]
        // public IActionResult Account()
        // {
        //     return View();
        // }
        //
        [Authorize]
        [HttpGet]
        public IActionResult CheckOut()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var cart = HttpContext.Session.Get<List<CartViewModel>>(cartKey+$"-{userId}");
            HttpContext.Session.Set<int>(totalItems+$"-{userId}",cart.Sum(o=>o.Quantity));
            var customer = _customer.getCustomer(userId);
            var checkout = new CheckoutViewModel()
            {   
                User = customer,
                Cart = cart,
                CartCounter = HttpContext.Session.Get<int>(counterKey+$"-{userId}")
            };
            HttpContext.Session.Set(orderKey+$"-{userId}",checkout);
            return View(checkout);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Checkout(string orderId)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var order=  HttpContext.Session.Get<CheckoutViewModel>(orderKey+$"-{userId}");
            _order.placeOrder(order);
            notify("Transaction Successful");
            return RedirectToAction("CustomerMenu","Home");
        }

        public IActionResult CustomerMenu()
        {
            var order = _order.getCustomerOrder(_userManager.GetUserId(HttpContext.User));
            return View(order);
        }
    }
}
