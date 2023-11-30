using AutomobileFactory.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileFactory.Entities.Classes
{
    internal class Sedan : ISedan
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Type: Sedan\nMake: {Make}\nModel: {Model}\nYear: {Year}");
        }
    }
}
