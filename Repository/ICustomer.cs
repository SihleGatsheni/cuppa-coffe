using onlineShop.Models;

namespace onlineShop.Repository;

public interface ICustomer
{
    public void AddCustomer(Customer customer, string userId);
    public Customer getCustomer(string id);
}