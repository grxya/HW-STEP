using System;
using System.Collections.Generic;

namespace HW1
{
    public class ProductList
    {
        public int Id { get; set; }
        public int? CarId { get; set; }
        public int? SellerId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Car? Car { get; set; }
        public Seller? Seller { get; set; }
    }
}
