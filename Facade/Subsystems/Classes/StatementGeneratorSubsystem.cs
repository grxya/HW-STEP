using Facade.Entities;
using Facade.Subsystems.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Subsystems.Classes
{
    class StatementGeneratorSubsystem : IStatementGeneratorSubsystem
    {
        public void WithdrawResult(bool successful, Card card, float amount)
        {
            if (successful)
            {
                Console.WriteLine($"Successful operation!\nWithdraw amount {amount}. Current balance {card.Balance}");
            }
            else
            {
                Console.WriteLine("Unsuccessful operation!\nThere are not enough funds in the bank account.");
            }
        }

        public void DepositResult(Card card, float amount)
        {
            Console.WriteLine($"New deposit!\nDeposit amount {amount}. Current balance {card.Balance}");
        }


        public void TransferResult(bool successful, Card card, float amount)
        {
            if (successful)
            {
                Console.WriteLine($"Successful operation!\nTransfered amount {amount}. Current balance {card.Balance}");
            }
            else
            {
                Console.WriteLine("Unsuccessful operation!\nThere are not enough funds in the bank account.");
            }
        }

    }
}
