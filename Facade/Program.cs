using Facade;
using Facade.Entities;
using Facade.Subsystems.Classes;

BankOperationsFacade facade = new BankOperationsFacade(new BalanceCheckerSubsystem(), new TransactionSubsystem(), new StatementGeneratorSubsystem());
Card sender = new Card(600);
Card receiver = new Card(200);

facade.TransferOperation(sender, receiver, 700); Console.WriteLine();
facade.WithdrawOperation(sender, 200); Console.WriteLine();
facade.DepositOperation(sender, 100); Console.WriteLine();
facade.TransferOperation(sender, receiver, 200); Console.WriteLine();
facade.WithdrawOperation(sender, 400); 