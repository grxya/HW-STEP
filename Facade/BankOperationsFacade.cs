using Facade.Entities;
using Facade.Subsystems.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class BankOperationsFacade
    {
        private readonly IBalanceCheckerSubsystem _checkerSubsystem;
        private readonly ITransactionSubsystem _transactionSubsystem;
        private readonly IStatementGeneratorSubsystem _statementGenerator;

        public BankOperationsFacade(IBalanceCheckerSubsystem checkerSubsystem, ITransactionSubsystem transactionSubsystem, IStatementGeneratorSubsystem statementGenerator)
        {
            _checkerSubsystem = checkerSubsystem;
            _transactionSubsystem = transactionSubsystem;
            _statementGenerator = statementGenerator;
        }

        public void WithdrawOperation(Card card, float amount)
        {
            if (_checkerSubsystem.Check(card, amount)) 
            { 
                _transactionSubsystem.Withdraw(card, amount);
                _statementGenerator.WithdrawResult(true, card, amount);
            }
            else
            {
                _statementGenerator.WithdrawResult(false, card, amount);
            }
        }

        public void DepositOperation(Card card, float amount)
        {
            _transactionSubsystem.Deposit(card, amount);
            _statementGenerator.DepositResult(card, amount);
        }

        public void TransferOperation(Card sender, Card receiver, float amount) 
        {
            if (_checkerSubsystem.Check(sender, amount))
            {
                _transactionSubsystem.Transfer(sender, receiver, amount);
                _statementGenerator.TransferResult(true, sender, amount);
            }
            else
            {
                _statementGenerator.TransferResult(false, sender, amount);
            }
        }
    }
}
