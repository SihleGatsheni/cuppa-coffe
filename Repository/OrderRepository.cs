using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using onlineShop.Models;
using onlineShop.ViewModel;

namespace onlineShop.Repository;

public class OrderRepository:IOrder
{
    private readonly ist3anContext _context;

    public OrderRepository(ist3anContext context)
    {
        _context = context;
    }
    public void placeOrder(CheckoutViewModel model)
    {
        var Id = _context.Sale.Max(o => o.SaleId);
        Sale sale = new Sale()
        {
            CustId = model.User.CustId,
            Date = DateTime.Now,
            EmpId = -1,
            TotalAmount = model.Cart.Sum(o=>o.Total)
        };

        _context.Sale.Add(sale);
        _context.SaveChanges();
        var orderId = _context.Sale.Max(o => o.SaleId);

        foreach (var order in model.Cart)
        {
            SaleItem saleItem = new SaleItem()
            {
                SaleId = orderId,
                ProdId = int.Parse(order.ItemId),
                Price = order.UnitPrice,
                Quantity = order.Quantity
            };

            _context.SaleItem.Add(saleItem);
            _context.SaveChanges();
        }

        foreach (var order in model.Cart)
        {
            var prod = _context.Inventory.SingleOrDefault(o => o.ProdId.Equals(int.Parse(order.ItemId)));
            prod.ProdQuantity = prod.ProdQuantity - order.Quantity;
            _context.Inventory.Attach(prod).Property(o => o.ProdCategory).IsModified = true;
            _context.SaveChanges();
        }
       
    }

    public OrderModel getCustomerOrder(string userId)
    {
        var customer= _context.Customer.SingleOrDefault(o => o.AspUserId.Equals(userId));
        var myList = new List<SaleItem>();
        if(customer != null)
        {
            var  customerOrders = _context.Sale.Where(o => o.CustId.Equals(customer.CustId)).ToList();
            var model = new OrderModel()
            {
                Items = myList,
                Orders = customerOrders,
                User = customer
            };
            return model;
        }

        return null;
    }

    public List<Sale> getOrders()
    {
        return _context.Sale.Include(o=>o.OrderItems).ToList() ?? null;
    }
}