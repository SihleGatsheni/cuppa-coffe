using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace onlineShop.Models
{
    public class Sale:IComparable<Sale>
    {
        public int SaleId { get; set; }
        public int? CustId { get; set; }
        public int? EmpId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }

        public virtual  List<SaleItem> OrderItems { get; set; }

        public int CompareTo(Sale other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return SaleId.CompareTo(other.SaleId);
        }
    }
}
