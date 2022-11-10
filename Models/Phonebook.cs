using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace onlineShop.Models
{
    public partial class Phonebook
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
