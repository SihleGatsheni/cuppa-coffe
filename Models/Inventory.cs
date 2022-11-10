using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace onlineShop.Models
{
    public partial class Inventory
    {
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public decimal ProdPrice { get; set; }
        public int ProdQuantity { get; set; }
        public int? ProdReOrderLevel { get; set; }
        public string Category { get; set; }
        public int? ProdCategory { get; set; }
        public string ImageUrl { get; set; }
    }
}
