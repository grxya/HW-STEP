using AbstractFactory.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Entities.Classes
{
    class Sneakers : IShoes
    {
        public int Size { get; set; }
        public string Color { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Daily Sneakers - Size: {Size} - Color: {Color}");
        }
    }
}
