using System;
using System.Collections.Generic;

namespace HW1
{
    public class Car
    {
        public Car()
        {
            ProductLists = new HashSet<ProductList>();
        }

        public int Id { get; set; }
        public string Brand { get; set; } 
        public string Model { get; set; } 
        public int Year { get; set; }
        public int? FuelTypeId { get; set; }
        public int? BodyTypeId { get; set; }
        public int? ColorId { get; set; }
        public string ImageLink { get; set; } 

        public  BodyType? BodyType { get; set; }
        public  Color? Color { get; set; }
        public  FuelType? FuelType { get; set; }
        public  ICollection<ProductList> ProductLists { get; set; }
    }
}
