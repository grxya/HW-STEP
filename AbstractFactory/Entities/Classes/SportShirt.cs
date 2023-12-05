using AbstractFactory.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Entities.Classes
{
    class SportShirt : IShirt
    {
        public string Size { get; set; }
        public string Style { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Sport Shirt - Size: {Size} - Style: {Style}");
        }
    }
}
