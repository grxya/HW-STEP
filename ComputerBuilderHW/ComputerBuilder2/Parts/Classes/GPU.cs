using ComputerBuilder.Parts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuilder.Parts.Classes
{
    class GPU : IPart
    {
        public string Name { get; set; }
        public double BaseSpeed { get; set; }
        public double BoostSpeed { get; set; }
    }
}
