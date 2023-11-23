using Monefy.Models;
using Monefy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Monefy.Services.Classes
{
    public class AccountService : IAccountsService
    {
        private readonly ISerializeService _serializeService;
        private const string _filepath = "Accounts.json";

        public ObservableCollection<AccountModel> Accounts { get; set; }

        public AccountService(ISerializeService serializeService)
        {
            _serializeService = serializeService;

            Accounts = _serializeService.Deserialize<AccountModel>(_filepath) ?? new ObservableCollection<AccountModel>();
        }

        public void Add(AccountModel newAccount)
        {
            Accounts.Add(newAccount);
            _serializeService.Serialize(Accounts, _filepath);
        }

        public void Update()
        {
            _serializeService.Serialize(Accounts, _filepath);
        }
    }
}
