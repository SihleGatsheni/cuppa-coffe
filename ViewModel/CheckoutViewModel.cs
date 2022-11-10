using System.Collections.Generic;
using onlineShop.Models;

namespace onlineShop.ViewModel;

public class CheckoutViewModel
{
    public Customer User { get; set; }
    public List<CartViewModel> Cart { get; set; }
    public int CartCounter { get; set; }
}