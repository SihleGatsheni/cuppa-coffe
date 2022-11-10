using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NdlovuCode.PaginatedList;
using onlineShop.Models;
using onlineShop.Repository;

namespace onlineShop.Controllers;

public class AdminController : Controller
{
    private readonly IOrder _order;

    public AdminController(IOrder order)
    {
        _order = order;
    }
    // GET
    public IActionResult Index(bool sort,bool shuffle, bool reverse,int pageNumber=1)
    {
        PaginatedList<Sale> myOrders = PaginatedList<Sale>.Create(_order.getOrders().OrderByDescending(o=>o.SaleId),pageNumber,12);
        if (sort)
        {
            myOrders.OrderByAscending();
        }

        if (reverse)
        {
            myOrders.OrderByDescending();
        }

        if (shuffle)
        {
            myOrders.Shuffle();
        }

        return View(myOrders);
    }
}