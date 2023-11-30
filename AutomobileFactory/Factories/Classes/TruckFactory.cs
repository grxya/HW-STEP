using AutomobileFactory.Entities.Classes;
using AutomobileFactory.Entities.Interfaces;
using AutomobileFactory.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileFactory.Factories.Classes
{
    internal class TruckFactory : IAutomobileFactory
    {
        public IAutomobile CreateAutomobile()
        {
            ITruck truck = new Truck()
            {
                Make = "Toyota",
                Model = "Tacoma",
                Year = 2020,
                Payload = 1440
            };

            return truck;
        }
    }
}
