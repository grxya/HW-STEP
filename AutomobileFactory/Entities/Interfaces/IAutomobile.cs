using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileFactory.Entities.Interfaces
{
    internal interface IAutomobile
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public void ShowInfo();
    }
}
