using AbstractFactory.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Entities.Classes
{
    class Trainers : IShoes
    {
        public int Size { get; set; }
        public string Brand { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Sport Trainers - Size: {Size} - Brand: {Brand}");
        }
    }
}
