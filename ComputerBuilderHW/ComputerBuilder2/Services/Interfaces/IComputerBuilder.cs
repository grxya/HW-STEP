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

        public void SetMotherboard(string name);
        public void SetCPU(string name, double speed, int cores);
        public void SetGPU(string name, double baseSpeed, double boostSpped);
        public void SetRAM(string name, int capacity, double speed);
    }
}
