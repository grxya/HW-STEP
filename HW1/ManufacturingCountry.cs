using System;
using System.Collections.Generic;

namespace HW1
{
    public class ManufacturingCountry
    {
        public ManufacturingCountry()
        {
            Sellers = new HashSet<Seller>();
        }

        public int Id { get; set; }
        public string Name { get; set; } 

        public ICollection<Seller> Sellers { get; set; }
    }
}
