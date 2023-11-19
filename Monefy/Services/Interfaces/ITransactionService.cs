using Monefy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Monefy.Services.Interfaces
{
    public interface ITransactionService
    {
        public ObservableCollection<TransactionModel> Transactions { get; set; }

        public void Add(TransactionModel newTransaction);
        public ObservableCollection<TransactionModel> GetAllExepenseTransaction();

    }
}
