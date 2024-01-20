using System;
using System.Collections.Generic;

namespace HW1
{
    public class FuelType
    {
        public FuelType()
        {
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }
        public string Name { get; set; } 

        public ICollection<Car> Cars { get; set; }
    }
}
