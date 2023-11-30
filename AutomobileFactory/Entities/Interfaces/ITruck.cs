using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileFactory.Entities.Interfaces
{
    interface ITruck : IAutomobile
    {
        public float Payload { get; set; }
    }
}
