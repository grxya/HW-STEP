using ComputerBuilder.Parts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuilder.Parts.Classes
{
    class RAM : IPart
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double Speed { get; set; }
    }
}
