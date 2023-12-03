using ComputerBuilder.Entities;
using ComputerBuilder.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuilder.Services.Classes
{
    internal class ComputerDirector
    {

        public Computer ConstructComputer(IComputerBuilder builder)
        {
            builder.SetMotherboard();
            builder.SetCPU();
            builder.SetGPU();
            builder.SetRAM();

            return builder.ComputerToBuild;
        }
    }
}
