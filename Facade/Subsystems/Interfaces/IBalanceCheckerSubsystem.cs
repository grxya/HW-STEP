using Facade.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Subsystems.Interfaces
{
    interface IBalanceCheckerSubsystem
    {
        public bool Check(Card card, float amount);
    }
}
