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

        public void SetMotherboard()
        {
            ComputerToBuild.AddPart(new Motherboard()
            {
                Name = "ASUS Integrated Motherboard"
            });
        }

        public void SetCPU()
        {
            ComputerToBuild.AddPart(new CPU()
            {
                Name = "Intel Core i5",
                ClockSpeed = 2.4,
                Cores = 4
            });
        }

        public void SetGPU()
        {
            ComputerToBuild.AddPart(new GPU()
            {
                Name = "Integrated Graphics",
                BaseSpeed = 0,
                BoostSpeed = 0
            });
        }

        public void SetRAM()
        {
            ComputerToBuild.AddPart(new RAM()
            {
                Name = "DDR4",
                Capacity = 16,
                Speed = 2400
            });
        }
    }
}
