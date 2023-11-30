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
    internal class SUVFactory : IAutomobileFactory
    {
        public IAutomobile CreateAutomobile()
        {
            ISUV suv = new SUV()
            {
                Make = "Hyundai",
                Model = "Tucson",
                Year = 2023
            };

            return suv;
        }
    }
}
