using System.Collections.Generic;
using onlineShop.Models;
using onlineShop.ViewModel;

namespace onlineShop.Repository;

public interface IOrder
{
    public void placeOrder(CheckoutViewModel model);
    public OrderModel getCustomerOrder(string userId);
    public List<Sale> getOrders();
}