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
    internal class DesignerComputerBuilder : IComputerBuilder
    {
        public Computer ComputerToBuild { get; set; }

        public DesignerComputerBuilder()
        {
            ComputerToBuild = new();
        }

        public void SetMotherboard()
        {
            ComputerToBuild.AddPart(new Motherboard()
            {
                Name = "HP Angel"
            });
        }

        public void SetCPU()
        {
            ComputerToBuild.AddPart(new CPU()
            {
                Name = "Intel Core i7",
                ClockSpeed = 4.9,
                Cores = 12
            });
        }

        public void SetGPU()
        {
            ComputerToBuild.AddPart(new GPU()
            {
                Name = "Nvidia Ge Force Rtx 3060",
                BaseSpeed = 1320,
                BoostSpeed = 1777
            });
        }

        public void SetRAM()
        {
            ComputerToBuild.AddPart(new RAM()
            {
                Name = "DDR5",
                Capacity = 16,
                Speed = 4000
            });
        }
    }
}
