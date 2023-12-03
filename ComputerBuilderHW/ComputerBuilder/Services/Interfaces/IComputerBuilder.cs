using ComputerBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuilder.Services.Interfaces
{
    internal interface IComputerBuilder
    {
        public Computer ComputerToBuild { get; set; }

        public void SetMotherboard();
        public void SetCPU();
        public void SetGPU();
        public void SetRAM();
    }
}
