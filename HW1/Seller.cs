using System;
using System.Collections.Generic;

namespace HW1
{
    public class Seller
    {
        public Seller()
        {
            ProductLists = new HashSet<ProductList>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public string CompanyName { get; set; } 
        public string ContactNumber { get; set; } 
        public int? ManufacturingCountryId { get; set; }
        public int Rating { get; set; }

        public ManufacturingCountry? ManufacturingCountry { get; set; }
        public User? User { get; set; }
        public ICollection<ProductList> ProductLists { get; set; }
    }
}
