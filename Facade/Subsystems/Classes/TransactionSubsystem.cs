using Facade.Entities;
using Facade.Subsystems.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Subsystems.Classes
{
    class TransactionSubsystem : ITransactionSubsystem
    {
        public void Transfer(Card sender, Card receiver, float amount)
        {
            sender.Balance -= amount;
            receiver.Balance += amount;
        }

        public void Deposit(Card card, float amount)
        {
            card.Balance += amount;
        }

        public void Withdraw(Card card, float amount)
        {
            card.Balance -= amount;
        }
    }
}
