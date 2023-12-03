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
    internal class GamingComputerBuilder : IComputerBuilder
    {
        public Computer ComputerToBuild { get; set; }

        public GamingComputerBuilder()
        {
            ComputerToBuild = new();
        }

        public void SetMotherboard()
        {
            ComputerToBuild.AddPart(new Motherboard()
            {
                Name = "Acer P07-650-UR12"
            });
        }

        public void SetCPU()
        {
            ComputerToBuild.AddPart(new CPU()
            {
                Name = "Intel Core i9",
                ClockSpeed = 3,
                Cores = 24
            });
        }

        public void SetGPU()
        {
            ComputerToBuild.AddPart(new GPU()
            {
                Name = "NVIDIA GeForce RTX 4090",
                BaseSpeed = 2235,
                BoostSpeed = 2520
            });
        }

        public void SetRAM()
        {
            ComputerToBuild.AddPart(new RAM()
            {
                Name = "DDR5",
                Capacity = 32,
                Speed = 3200
            });
        }
    }
}
