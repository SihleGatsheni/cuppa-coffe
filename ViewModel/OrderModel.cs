using System.Collections.Generic;
using onlineShop.Models;

namespace onlineShop.ViewModel;

public class OrderModel
{
    public IEnumerable<Sale> Orders { get; set; }
    public Customer User  { get; set; }
    public IEnumerable<SaleItem> Items { get; set; }
}