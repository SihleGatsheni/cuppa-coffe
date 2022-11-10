using onlineShop.Models;
using onlineShop.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace onlineShop.Repository
{
    public class ProductRepository:IRepo
    { 
        private ist3anContext _context;
        public ProductRepository(ist3anContext context)
        {
            this._context = context;
        }
        public List<ProductViewModel> getAllProducts()
        {
            var productList = _context.Inventory.ToList();
            var products = new List<ProductViewModel>();
            if (productList != null)
            {
                foreach (Inventory product in productList)
                {
                    products.Add(new ProductViewModel()
                    {
                        Name = product.ProdName,
                        ProductId = product.ProdId,
                        ProductCategory = product.Category,
                        UnitInStock = product.ProdQuantity,
                        SellingPrice = product.ProdPrice,
                        Image = product.ImageUrl
                    });
                }
                return products;
            }
            return new List<ProductViewModel>();
        }

        public Inventory getInventory(int Id)
        {
            var product = _context.Inventory.SingleOrDefault(o => o.ProdId.Equals(Id));
            return product ?? null;
        }

        public List<ProductViewModel> getByCategory(string category)
        {
            var productList = _context.Inventory.Where(o=>o.Category.Equals(category)).ToList();
            var products = new List<ProductViewModel>();
            if (productList != null)
            {
                foreach (Inventory product in productList)
                {
                    products.Add(new ProductViewModel()
                    {
                        Name = product.ProdName,
                        ProductId = product.ProdId,
                        ProductCategory = product.Category,
                        UnitInStock = product.ProdQuantity,
                        SellingPrice = product.ProdPrice,
                        Image = product.ImageUrl
                    });
                }
                return products;
            }
            return new List<ProductViewModel>();
        }
    }
}
