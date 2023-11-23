using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monefy.Services.Interfaces;
using Monefy.Models;
using System.Transactions;

namespace Monefy.Services.Classes
{
    public class TransactionService : ITransactionService
    {
        private readonly ISerializeService _serializeService;
        private const string _filepath = "Transactions.json";

        public ObservableCollection<TransactionModel> Transactions { get; set; }

        public TransactionService(ISerializeService serializeService)
        {
            _serializeService = serializeService;

            Transactions = _serializeService.Deserialize<TransactionModel>(_filepath) ?? new ObservableCollection<TransactionModel>();
        }

        public void Add(TransactionModel newTransaction)
        {
            Transactions.Add(newTransaction);
            _serializeService.Serialize(Transactions, _filepath);
        }

        public ObservableCollection<TransactionModel> GetAllExepenseTransaction()
        {
            var expenseTransactions = new ObservableCollection<TransactionModel>
            (
                Transactions.Where(t => t.type == Enum.TransactionType.Expense)
            );

            return expenseTransactions;
        }
    }
}
