using onlineShop.ViewModel;
using System.Collections.Generic;
using onlineShop.Models;

namespace onlineShop.Repository
{
    public interface IRepo
    {
        public List<ProductViewModel> getAllProducts();
        public Inventory getInventory(int Id);
        public List<ProductViewModel> getByCategory(string category);
    }
}
