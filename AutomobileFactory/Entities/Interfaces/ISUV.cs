using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileFactory.Entities.Interfaces
{
    interface ISUV : IAutomobile
    {
        public bool IsOffRoad { get; }
    }
}
