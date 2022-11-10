using System.Linq;
using onlineShop.Models;

namespace onlineShop.Repository;

public class CustomerRepository:ICustomer
{
    private readonly ist3anContext _context;

    public CustomerRepository(ist3anContext context)
    {
        _context = context;
    }
    public void AddCustomer(Customer cust, string custId)
    {
        Customer customer = new Customer()
        {
            FirstName = cust.FirstName,
            LastName = cust.LastName,
            Email = cust.Email,
            AspUserId = custId,
            Address = cust.Address,
            Tel = cust.Tel,
            Zipcode = cust.Zipcode,
            City = cust.City
        };
        _context.Customer.Add(customer);
        _context.SaveChanges();
    }

    public Customer getCustomer(string id)
    {
        var customer = _context.Customer.SingleOrDefault(o => o.AspUserId.Equals(id));
        return customer ?? null;
    }
}