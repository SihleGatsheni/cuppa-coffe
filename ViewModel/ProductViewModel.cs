namespace onlineShop.ViewModel
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public string ProductCategory { get; set; }
        public int UnitInStock { get; set; }
        public int ReorderLevel { get; set; }
        public decimal SellingPrice { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
