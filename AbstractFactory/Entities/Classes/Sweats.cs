using AbstractFactory.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Entities.Classes
{
    class Sweats : ITrousers
    {
        public int Size { get; set; }
        public string Color { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Sport Sweats - Size: {Size} - Color: {Color}");
        }
    }
}
