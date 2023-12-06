using Facade.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Subsystems.Interfaces
{
    interface ITransactionSubsystem
    {
        public void Transfer(Card sender, Card receiver, float amount);
        public void Deposit(Card card, float amount);
        public void Withdraw(Card card, float amount);
    }
}
