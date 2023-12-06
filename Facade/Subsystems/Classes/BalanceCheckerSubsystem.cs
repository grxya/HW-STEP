using Facade.Entities;
using Facade.Subsystems.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Subsystems.Classes
{
    class BalanceCheckerSubsystem : IBalanceCheckerSubsystem
    {
        public bool Check(Card card, float amount)
        {
            if (card.Balance >= amount) return true;
            else return false;
        }
    }
}
