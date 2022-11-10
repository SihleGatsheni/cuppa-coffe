using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace onlineShop.Models
{
    public partial class Product
    {
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public string ProdType { get; set; }
        public int ProdPrice { get; set; }
        public DateTime ProdDate { get; set; }
    }
}
