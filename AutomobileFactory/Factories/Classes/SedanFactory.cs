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
    internal class SedanFactory : IAutomobileFactory
    {
        public IAutomobile CreateAutomobile()
        {
            ISedan sedan = new Sedan()
            {
                Make = "Kia",
                Model = "Rio",
                Year = 2022
            };

            return sedan;
        }
    }
}
