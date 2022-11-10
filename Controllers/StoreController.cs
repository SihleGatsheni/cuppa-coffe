using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace onlineShop.Controllers
{
	public class StoreController : Controller
	{
		[Authorize]
		public IActionResult ShoppingCart()
		{
			return View();
		}

		[Authorize]
		public IActionResult WishList()
		{
			return View();
		}
	}
}
