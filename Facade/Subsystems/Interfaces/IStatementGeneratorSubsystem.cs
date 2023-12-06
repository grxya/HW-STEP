using Facade.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Subsystems.Interfaces
{
    interface IStatementGeneratorSubsystem
    {
        public void WithdrawResult(bool successful, Card card, float amount);
        public void DepositResult(Card card, float amount);
        public void TransferResult(bool successful, Card card, float amount);
    }
}
