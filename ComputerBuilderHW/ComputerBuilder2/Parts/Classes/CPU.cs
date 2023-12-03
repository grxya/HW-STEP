using ComputerBuilder.Parts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuilder.Parts.Classes
{
    class CPU : IPart
    {
        public string Name { get; set; }
        public int Cores { get; set; }
        public double ClockSpeed { get; set; }
    }
}
