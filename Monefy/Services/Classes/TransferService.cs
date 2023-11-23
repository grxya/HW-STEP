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
    public class TransferService : ITransferService
    {
        private readonly ISerializeService _serializeService;
        private const string _filepath = "Transfers.json";

        public ObservableCollection<TransferModel> Transfers { get; set; }

        public TransferService(ISerializeService serializeService)
        {
            _serializeService = serializeService;

            Transfers = _serializeService.Deserialize<TransferModel>(_filepath) ?? new ObservableCollection<TransferModel>();
        }

        public void Add(TransferModel newTransfer)
        {
            Transfers.Add(newTransfer);
            _serializeService.Serialize(Transfers, _filepath);
        }
    }
}
