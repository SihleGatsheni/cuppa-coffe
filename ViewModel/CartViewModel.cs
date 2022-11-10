namespace onlineShop.ViewModel;

public class CartViewModel
{
    public string ItemId { get; set; }
    public string ItemName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Total { get; set; }
    public string ImageUrl { get; set; }
}