using Monefy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Services.Interfaces
{
    public interface IAccountsService
    {
        public ObservableCollection<AccountModel> Accounts { get; set; }

        public void Add(AccountModel newAccount);
        public void Update();
    }
}
