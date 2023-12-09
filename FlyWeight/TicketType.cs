using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeight
{
    class TicketType
    {
        public string Category { get; }
        public double Price { get; }

        public TicketType(string category, double price)
        {
            Category = category;
            Price = price;
        }

        public void TypeInfo()
        {
            Console.WriteLine($"Category: {Category}\nPrice: {Price}");
        }
    }
}
