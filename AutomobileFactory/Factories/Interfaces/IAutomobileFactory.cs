using AutomobileFactory.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileFactory.Factories.Interfaces
{
    internal interface IAutomobileFactory
    {
        public IAutomobile CreateAutomobile();
    }
}
