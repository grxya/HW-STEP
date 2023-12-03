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
        private IComputerBuilder _builder;

        public Computer ConstructDesigner()
        {
            _builder = new DesignerComputerBuilder();

            _builder.SetMotherboard("HP Angel");
            _builder.SetCPU("Intel Core i7", 4.9, 12);
            _builder.SetGPU("Nvidia Ge Force Rtx 3060", 1320, 1777);
            _builder.SetRAM("DDR5", 16, 4000);

            return _builder.ComputerToBuild;
        }

        public Computer ConstructGaming()
        {
            _builder = new GamingComputerBuilder();

            _builder.SetMotherboard("Acer P07-650-UR12");
            _builder.SetCPU("Intel Core i9", 3, 24);
            _builder.SetGPU("Nvidia GeForce Rtx 4090", 2235, 2520);
            _builder.SetRAM("DDR5", 32, 3200);

            return _builder.ComputerToBuild;
        }

        public Computer ConstructOffice()
        {
            _builder = new OfficeComputerBuilder();

            _builder.SetCPU("Intel Core i5", 2.4, 4);
            _builder.SetGPU("Integrated Graphics", 0, 0);
            _builder.SetMotherboard("ASUS Integrated Motherboard"); // специально чтобы показать разницу от порядка 
            _builder.SetRAM("DDR4", 16, 2400);

            return _builder.ComputerToBuild;
        }
    }
}
