using ComputerBuilder.Entities;
using ComputerBuilder.Parts.Classes;
using ComputerBuilder.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuilder.Services.Classes
{
    internal class OfficeComputerBuilder : IComputerBuilder
    {
        public Computer ComputerToBuild { get; set; }

        public OfficeComputerBuilder()
        {
            ComputerToBuild = new();
        }

       public void SetMotherboard(string name)
        {
            ComputerToBuild.AddPart(new Motherboard()
            {
                Name = name
            });
        }

        public void SetCPU(string name, double speed, int cores)
        {
            ComputerToBuild.AddPart(new CPU()
            {
                Name = name,
                ClockSpeed = speed,
                Cores = cores
            });
        }

        public void SetGPU(string name, double baseSpeed, double boostSpped)
        {
            ComputerToBuild.AddPart(new GPU()
            {
                Name = name,
                BaseSpeed = baseSpeed,
                BoostSpeed = boostSpped
            });
        }

        public void SetRAM(string name, int capacity, double speed)
        {
            ComputerToBuild.AddPart(new RAM()
            {
                Name = name,
                Capacity = capacity,
                Speed = speed
            });
        }
    }
}
