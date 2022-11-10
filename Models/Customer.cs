using System.ComponentModel.DataAnnotations.Schema;

namespace onlineShop.Models;

public class Customer
{
    public int CustId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Tel { get; set; }
    public string AspUserId { get; set; }
    public string Address { get; set; }
    public string Zipcode { get; set; }
    public string City { get; set; }
    
    [NotMapped] 
    public string FullName
    {
        get { return FirstName + " " + LastName; }
    }
}